using AN.BLL.Core.Services;
using AN.BLL.Helpers;
using AN.Core.Domain;
using AN.Core.DTO;
using AN.Core.DTO.Turn;
using AN.Core.Enums;
using AN.Core.Exceptions;
using AN.Core.Extensions;
using AN.Core.Models;
using AN.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AN.BLL.Services.Offers
{
    public class OffersService : IOffersService
    {
        private readonly BanobatDbContext _dbContext;
        private readonly IDoctorServiceManager _doctorServiceManager;
        public OffersService(BanobatDbContext dbContext, IDoctorServiceManager doctorServiceManager)
        {
            _dbContext = dbContext;
            _doctorServiceManager = doctorServiceManager;
        }

        public async Task<OffersDataDTO> GetOffersDataAsync(Lang lang, string hostAddress, int? cityId = null)
        {
            IQueryable<Offer> query = _dbContext.Set<Offer>().Include(x => x.ShiftCenterService).ThenInclude(x => x.ShiftCenter);

            query = query.Where(x => x.Status == OfferStatus.APPROVED);

            query = query.Where(x => DateTime.Now >= x.StartAt && DateTime.Now <= x.ExpiredAt);

            query = query.Where(x => x.Type != OfferType.FREE_APPOINTMENTS || x.RemainedCount > 0);

            query = query.Where(x => x.ShiftCenterService != null && x.ShiftCenterService.Service != null);

            if(cityId != null)
            {
                query = query.Where(x => x.ShiftCenterService.ShiftCenter.CityId == cityId);
            }

            var offersGroups = await query.GroupBy(x => x.ShiftCenterService.Service.ServiceCategoryId).Select(c => new
            {
                CategoryId = c.Key,
                OffersCount = c.Count(),
                VisitsCount = c.Sum(v => v.VisitsCount)
            }).ToListAsync();

            var trendingCategory = offersGroups.OrderByDescending(o => o.OffersCount).ThenByDescending(o => o.VisitsCount).FirstOrDefault();

            var categories = await _dbContext.ServiceCategories.Where(x => x.Services.Any(s => s.ShiftCenterServices.Any(h => (cityId == null || h.ShiftCenter.CityId == cityId) && h.Offers.Any(o => o.Status == OfferStatus.APPROVED && (DateTime.Now >= o.StartAt && DateTime.Now <= o.ExpiredAt) && (o.Type != OfferType.FREE_APPOINTMENTS || o.RemainedCount > 0))))).Select(c => new OfferCategoryDTO
            {
               Id = c.Id,
               Title = lang == Lang.KU ? c.Name_Ku : lang == Lang.AR ? c.Name_Ar : c.Name,
               Photo = $"{hostAddress}{c.RealPhoto}",
               IsTrending = trendingCategory != null && trendingCategory.CategoryId == c.Id,
               Services = c.Services.Select(s => new MySelectListItem
               {
                   Text = lang == Lang.KU ? s.Name_Ku : lang == Lang.AR ? s.Name_Ar : s.Name,
                   Value = s.Id.ToString()
               }).ToList()
            }).ToListAsync();

            var offers = await query.Select(x => new OfferItemDTO
            {
                Id = x.Id,
                ShiftCenterServiceId = x.ShiftCenterServiceId ?? 0,
                ServiceSupplyId = x.ServiceSupplyId,
                CurrencyType = x.CurrencyType == CurrencyType.USD ? "USD" : "IQD",
                OldPrice = x.OldPrice,
                CurrentPrice = x.CurrentPrice,
                DiscountPercentange = x.DiscountPercentange,
                ShowDiscountBanner = x.ShowDiscountBanner,
                Summary = lang == Lang.KU ? x.Summary_Ku : lang == Lang.AR ? x.Summary_Ar : x.Summary,
                Title = lang == Lang.KU ? x.Title_Ku : lang == Lang.AR ? x.Title_Ar : x.Title,
                Photos = new List<string>
                {
                    lang == Lang.KU ? $"{hostAddress}{x.Photo_Ku}" : lang == Lang.AR ?$"{hostAddress}{x.Photo_Ar}" : $"{hostAddress}{x.Photo}",
                },
                Photo = lang == Lang.KU ? $"{hostAddress}{x.Photo_Ku}" : lang == Lang.AR ? $"{hostAddress}{x.Photo_Ar}" : $"{hostAddress}{x.Photo}",
                AppointmentsCount = x.Appointments.Count,
                VisitsCount = x.VisitsCount,
                CreatedAt = x.CreatedAt
            }).ToListAsync();

            foreach (var item in offers)
            {
                var serviceSupply = await _dbContext.ServiceSupplies.FindAsync(item.ServiceSupplyId);

                if (serviceSupply == null) throw new AwroNoreException("Offer Doctor Not Found");

                var x = serviceSupply;

                var shiftCenterService = x.ShiftCenter.PolyclinicHealthServices.FirstOrDefault(ss => ss.Id == item.ShiftCenterServiceId);

                item.ServiceSupply = new AN.Core.DTO.Doctors.DoctorListItemDTO
                {
                    Id = x.Id,
                    FullName = lang == Lang.KU ? x.Person.FullName_Ku : lang == Lang.AR ? x.Person.FullName_Ar : x.Person.FullName,
                    Avatar = x.Person.RealAvatar,
                    ExpertiseCategory = x.DoctorExpertises.FirstOrDefault() != null ? lang == Lang.AR ? x.DoctorExpertises.FirstOrDefault().Expertise.ExpertiseCategory.Name_Ar : x.DoctorExpertises.FirstOrDefault().Expertise.ExpertiseCategory.Name_Ku : "",
                    Address = lang == Lang.KU ? x.ShiftCenter.Address_Ku : x.ShiftCenter.Address_Ar,
                    HasEmptyTurn = _doctorServiceManager.FindFirstEmptyTimePeriodFromNow(serviceSupply, shiftCenterService) != null,
                    AverageRating = x.AverageRating != null ? (double)Math.Round((decimal)x.AverageRating, 2) : 5,
                    CenterServiceId = item.ShiftCenterServiceId,
                    Service = shiftCenterService == null ? "" : lang == Lang.KU ? shiftCenterService.Service.Name_Ku : lang == Lang.AR ? shiftCenterService.Service.Name_Ar : shiftCenterService.Service.Name,
                    ReservationType = x.ReservationType,
                    CenterType = x.ShiftCenter.Type
                };
            }

            var sortByData = new List<MySelectListItem>
            {
                new MySelectListItem{ Text = OfferSort.Booking.GetLocalizedDisplayName(), Value = "0"},
                new MySelectListItem{ Text = OfferSort.Visits.GetLocalizedDisplayName(), Value = "1"},
                new MySelectListItem{ Text = OfferSort.Price.GetLocalizedDisplayName(), Value = "2"}
            };

            var sortDirData = new List<MySelectListItem>
            {
                 new MySelectListItem{ Text = SortDir.ASC.GetLocalizedDisplayName(), Value = "0"},
                new MySelectListItem{ Text = SortDir.DESC.GetLocalizedDisplayName(), Value = "1"},
            };

            var minPrice = offers.Any() ? (offers.OrderBy(o => o.CurrentPrice).Select(o => o.CurrentPrice).Min() ?? 0) : 0;
            var maxPrice = offers.Any() ? (offers.OrderBy(o => o.CurrentPrice).Select(o => o.CurrentPrice).Max() ?? 1000000) : 1000000;

            var result = new OffersDataDTO
            {
                SlideShow = offers,
                Categories = categories,
                TrendingNow = offers.OrderByDescending(o => o.CreatedAt).ThenByDescending(o => o.VisitsCount).Take(20).ToList(),
                All = offers.OrderByDescending(o => o.AppointmentsCount).ToList(),
                FiltersData = new OffersFilterDataDTO
                {
                    SortBy = sortByData,
                    SortDir = sortDirData,
                    MinPrice = minPrice,
                    MaxPrice = maxPrice
                }
            };

            return result;
        }

        public async Task<List<OfferItemDTO>> GetOffersByCategoryAsync(Lang lang, string hostAddress, OffersFilterDTO filters)
        {
            IQueryable<Offer> query = _dbContext.Set<Offer>().Include(x => x.ShiftCenterService).ThenInclude(x => x.ShiftCenter);

            query = query.Where(x => x.Status == OfferStatus.APPROVED);

            query = query.Where(x => DateTime.Now >= x.StartAt && DateTime.Now <= x.ExpiredAt);

            query = query.Where(x => x.Type != OfferType.FREE_APPOINTMENTS || x.RemainedCount > 0);

            if (filters.CityId != null)
            {
                query = query.Where(x => x.ShiftCenterService.ShiftCenter.CityId == filters.CityId);
            }

            if (filters.ServiceCategoryId != null)
            {
                query = query.Where(x => x.ShiftCenterService.Service.ServiceCategoryId == filters.ServiceCategoryId);
            }

            if(filters.ServiceId != null)
            {
                query = query.Where(x => x.ShiftCenterService.HealthServiceId == filters.ServiceId);
            }

            if(filters.MinPrice != null)
            {
                query = query.Where(x => x.CurrentPrice != null && x.CurrentPrice >= filters.MinPrice);
            }

            if (filters.MaxPrice != null)
            {
                query = query.Where(x => x.CurrentPrice != null && x.CurrentPrice <= filters.MaxPrice);
            }

            if(filters.SortBy != null)
            {
                if(filters.SortDir == SortDir.ASC)
                {
                    if (filters.SortBy == OfferSort.Booking) query = query.OrderBy(x => x.Appointments.Count);
                    if (filters.SortBy == OfferSort.Visits) query = query.OrderBy(x => x.VisitsCount);
                    if (filters.SortBy == OfferSort.Price) query = query.OrderBy(x => x.CurrentPrice);
                }
                else
                {
                    if (filters.SortBy == OfferSort.Booking) query = query.OrderByDescending(x => x.Appointments.Count);
                    if (filters.SortBy == OfferSort.Visits) query = query.OrderByDescending(x => x.VisitsCount);
                    if (filters.SortBy == OfferSort.Price) query = query.OrderByDescending(x => x.CurrentPrice);
                }
            }
            else
            {
                query = query.OrderByDescending(x => x.CreatedAt);
            }

            var offers = await query.Select(x => new OfferItemDTO
            {
                Id = x.Id,
                ShiftCenterServiceId = x.ShiftCenterServiceId ?? 0,
                ServiceSupplyId = x.ServiceSupplyId,
                CurrencyType = x.CurrencyType == CurrencyType.USD ? "USD" : "IQD",
                OldPrice = x.OldPrice,
                CurrentPrice = x.CurrentPrice,
                DiscountPercentange = x.DiscountPercentange,
                ShowDiscountBanner = x.ShowDiscountBanner,
                Summary = lang == Lang.KU ? x.Summary_Ku : lang == Lang.AR ? x.Summary_Ar : x.Summary,
                Title = lang == Lang.KU ? x.Title_Ku : lang == Lang.AR ? x.Title_Ar : x.Title,
                Photos = new List<string>
                {
                    lang == Lang.KU ? $"{hostAddress}{x.Photo_Ku}" : lang == Lang.AR ?$"{hostAddress}{x.Photo_Ar}" : $"{hostAddress}{x.Photo}",
                },
                Photo = lang == Lang.KU ? $"{hostAddress}{x.Photo_Ku}" : lang == Lang.AR ? $"{hostAddress}{x.Photo_Ar}" : $"{hostAddress}{x.Photo}",
            }).ToListAsync();

            foreach (var item in offers)
            {
                var serviceSupply = await _dbContext.ServiceSupplies.FindAsync(item.ServiceSupplyId);

                if (serviceSupply == null) throw new AwroNoreException("Offer Doctor Not Found");

                var x = serviceSupply;

                var shiftCenterService = x.ShiftCenter.PolyclinicHealthServices.FirstOrDefault(ss => ss.Id == item.ShiftCenterServiceId);

                item.ServiceSupply = new AN.Core.DTO.Doctors.DoctorListItemDTO
                {
                    Id = x.Id,
                    FullName = lang == Lang.KU ? x.Person.FullName_Ku : lang == Lang.AR ? x.Person.FullName_Ar : x.Person.FullName,
                    Avatar = x.Person.RealAvatar,
                    ExpertiseCategory = x.DoctorExpertises.FirstOrDefault() != null ? lang == Lang.AR ? x.DoctorExpertises.FirstOrDefault().Expertise.ExpertiseCategory.Name_Ar : x.DoctorExpertises.FirstOrDefault().Expertise.ExpertiseCategory.Name_Ku : "",
                    Address = lang == Lang.KU ? x.ShiftCenter.Address_Ku : x.ShiftCenter.Address_Ar,
                    HasEmptyTurn = _doctorServiceManager.FindFirstEmptyTimePeriodFromNow(serviceSupply, shiftCenterService) != null,
                    AverageRating = x.AverageRating != null ? (double)Math.Round((decimal)x.AverageRating, 2) : 5,
                    CenterServiceId = item.ShiftCenterServiceId,
                    Service = shiftCenterService == null ? "" : lang == Lang.KU ? shiftCenterService.Service.Name_Ku : lang == Lang.AR ? shiftCenterService.Service.Name_Ar : shiftCenterService.Service.Name,
                    ReservationType = x.ReservationType,
                    CenterType = x.ShiftCenter.Type
                };
            }

            return offers;
        }

        public async Task<(long totalCount, int totalPages, List<OfferItemDTO>)> GetOffersListAsync(Lang lang, string hostAddress, int page = 0, int pageSize = 12, bool supportBasicOffers = false)
        {
            IQueryable<Offer> query = _dbContext.Set<Offer>();

            query = query.Where(x => x.Status == OfferStatus.APPROVED);

            if (!supportBasicOffers)
            {
                query = query.Where(x => x.Type != OfferType.AD);
            }

            query = query.Where(x => DateTime.Now >= x.StartAt && DateTime.Now <= x.ExpiredAt);

            query = query.Where(x => x.Type != OfferType.FREE_APPOINTMENTS || x.RemainedCount > 0);

            var totalCount = await query.LongCountAsync();

            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            var offers = await query.OrderByDescending(x => x.CreatedAt).Select(x => new OfferItemDTO
            {
                Id = x.Id,
                ShiftCenterServiceId = x.ShiftCenterServiceId ?? 0,
                ServiceSupplyId = x.ServiceSupplyId,
                CurrencyType = x.CurrencyType == CurrencyType.USD ? "USD" : "IQD",
                OldPrice = x.OldPrice,
                CurrentPrice = x.CurrentPrice,
                DiscountPercentange = x.DiscountPercentange,
                ShowDiscountBanner = x.ShowDiscountBanner,
                Summary = lang == Lang.KU ? x.Summary_Ku : lang == Lang.AR ? x.Summary_Ar : x.Summary,
                Title = lang == Lang.KU ? x.Title_Ku : lang == Lang.AR ? x.Title_Ar : x.Title,
                Photos = new List<string>
                {
                    lang == Lang.KU ? $"{hostAddress}{x.Photo_Ku}" : lang == Lang.AR ?$"{hostAddress}{x.Photo_Ar}" : $"{hostAddress}{x.Photo}",
                },
                //Photo = lang == Lang.KU ? $"{hostAddress}{x.Photo_Ku}" : lang == Lang.AR ? $"{hostAddress}{x.Photo_Ar}" : $"{hostAddress}{x.Photo}",
                Photo = $"{hostAddress}{x.Photo}",
            }).ToListAsync();

            foreach (var item in offers)
            {
                var serviceSupply = await _dbContext.ServiceSupplies.FindAsync(item.ServiceSupplyId);

                if (serviceSupply == null) throw new AwroNoreException("Offer Doctor Not Found");

                var x = serviceSupply;

                var shiftCenterService = x.ShiftCenter.PolyclinicHealthServices.FirstOrDefault(ss => ss.Id == item.ShiftCenterServiceId);

                item.ServiceSupply = new AN.Core.DTO.Doctors.DoctorListItemDTO
                {
                    Id = x.Id,
                    FullName = lang == Lang.KU ? x.Person.FullName_Ku : lang == Lang.AR ? x.Person.FullName_Ar : x.Person.FullName,
                    Avatar = x.Person.RealAvatar,
                    ExpertiseCategory = x.DoctorExpertises.FirstOrDefault() != null ? lang == Lang.AR ? x.DoctorExpertises.FirstOrDefault().Expertise.ExpertiseCategory.Name_Ar : x.DoctorExpertises.FirstOrDefault().Expertise.ExpertiseCategory.Name_Ku : "",
                    Address = lang == Lang.KU ? x.ShiftCenter.Address_Ku : x.ShiftCenter.Address_Ar,
                    HasEmptyTurn = _doctorServiceManager.FindFirstEmptyTimePeriodFromNow(serviceSupply, shiftCenterService) != null,
                    AverageRating = x.AverageRating != null ? (double)Math.Round((decimal)x.AverageRating, 2) : 5,
                    CenterServiceId = item.ShiftCenterServiceId,
                    Service = shiftCenterService == null ? "" : lang == Lang.KU ? shiftCenterService.Service.Name_Ku : lang == Lang.AR ? shiftCenterService.Service.Name_Ar : shiftCenterService.Service.Name,
                    ReservationType = x.ReservationType,
                    CenterType = x.ShiftCenter.Type
                };
            }

            return (totalCount, totalPages, offers);
        }

        public async Task<OfferTimePeriodsDTO> GetOfferTimePeriodsAsync(int id)
        {
            var offer = await _dbContext.Offers.FirstOrDefaultAsync(x => x.Id == id);

            if (offer == null) throw new AwroNoreException("Offer Not Found");

            if (offer.Type != OfferType.FREE_APPOINTMENTS || offer.StartDateTime == null) return new OfferTimePeriodsDTO
            {
                Id = id,
                Date = "",
                Code = offer.Code ?? "",
                ServiceSupplyId = offer.ServiceSupplyId,
                RemainedCount = 0,
                MaxCount = 0,
                ShiftCenterServiceId = offer.ShiftCenterServiceId ?? 0,
                DayOfWeek = "",
                EndTime = "",
                StartTime = "",
                TimePeriods = new List<TurnTimePeriodDTO>()
            };

            var result = new OfferTimePeriodsDTO
            {
                Id = id,
                Date = offer.StartDateTime.Value.ToShortDateString(),
                StartTime = offer.StartDateTime.Value.ToShortTimeString(),
                EndTime = offer.EndDateTime.Value.ToShortTimeString(),
                DayOfWeek = Utils.ConvertDayOfWeek(offer.StartDateTime.Value.DayOfWeek.ToString()),
                ServiceSupplyId = offer.ServiceSupplyId,
                ShiftCenterServiceId = offer.ShiftCenterServiceId ?? 0,
                MaxCount = offer.MaxCount ?? 0,
                RemainedCount = offer.RemainedCount ?? 0,
                Code = offer.Code,
                TimePeriods = new List<TurnTimePeriodDTO>()
            };

            var allTimePeriods = _doctorServiceManager.CalculateAllTimePeriodsForOffer(offer);

            if (allTimePeriods != null)
            {
                result.TimePeriods = allTimePeriods.Select(x => new TurnTimePeriodDTO
                {
                    Date = x.StartDateTime.ToShortDateString(),
                    StartTime = x.StartDateTime.ToString("HH:mm"),
                    EndTime = x.EndDateTime.ToString("HH:mm"),
                    Duration = x.Duration,
                    Type = x.Type,
                    TypeName = x.Type.GetLocalizedDisplayName()
                }).ToList();
            }

            return result;
        }
    }
}

using AN.BLL.Extensions;
using AN.Core.Domain;
using AN.Core.DTO;
using AN.Core.Enums;
using AN.Core.Exceptions;
using AN.Core.Models;
using AN.Core.Resources.Global;
using AN.DAL;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AN.BLL.Services
{
    public class HealthBankService : IHealthBankService
    {
        private readonly BanobatDbContext _dbContext;
        public HealthBankService(BanobatDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<HealthBankCategoryDTO>> GetHealthBankCategoriesAsync(Lang lang, string hostAddress, int? cityId = null)
        {
            IQueryable<Hospital> hospitalsQuery = _dbContext.Hospitals;

            if (cityId != null)
            {
                hospitalsQuery = hospitalsQuery.Where(x => x.CityId == cityId);
            }

            IQueryable<Clinic> clinicsQuery = _dbContext.Clinics;

            if (cityId != null)
            {
                clinicsQuery = clinicsQuery.Where(x => x.CityId == cityId);
            }

            IQueryable<ShiftCenter> centersQuery = _dbContext.ShiftCenters.Where(x => x.IsApproved && x.IsIndependent && x.ShowInHealthBank);

            if (cityId != null)
            {
                centersQuery = centersQuery.Where(x => x.CityId == cityId);
            }

            var result = new List<HealthBankCategoryDTO>
            {
                new HealthBankCategoryDTO
                {
                    Type = HealthBankCategoryType.HOSPITAL,
                    Name = Global.Hospitals,
                    Icon = $"{hostAddress}/images/centers/hospital/hospital.png",
                    Count = await hospitalsQuery.CountAsync()
                },
                new HealthBankCategoryDTO
                {
                    Type = HealthBankCategoryType.CLINIC,
                    Name = Global.Clinics,
                    Icon = $"{hostAddress}/images/centers/clinic/clinic.png",
                    Count = await clinicsQuery.CountAsync()
                },
            };

            var centersResult = await centersQuery.GroupBy(x => x.Type).Select(x => new HealthBankCategoryDTO
            {
                Type = HealthBankCategoryType.SHIFT_CENTER,
                Name = x.Key.GetLocalizedDisplayName(),
                Icon = $"{hostAddress}/images/centers/{x.Key.GetCenterTypeIconsFolderName()}/{x.Key.GetCenterTypeIconsFolderName()}.png",
                Count = x.Count(),
                CenterType = x.Key
            }).ToListAsync();

            result.AddRange(centersResult);

            return result;
        }

        public async Task<HealthBankItemsPagingResultDTO> GetHelathBankItemsAsync(HealthBankCategoryType type, Lang lang, string hostAddress, ShiftCenterType? centerType = null, int? cityId = null, string filterString = "", int page = 0, int pageSize = 12)
        {
            if (type == HealthBankCategoryType.HOSPITAL)
            {
                IQueryable<Hospital> hospitalsQuery = _dbContext.Hospitals;

                if (cityId != null) hospitalsQuery = hospitalsQuery.Where(x => x.CityId == cityId);

                if (!string.IsNullOrEmpty(filterString)) hospitalsQuery.Where(x => x.Name.Contains(filterString) || x.Name_Ku.Contains(filterString) || x.Name_Ar.Contains(filterString));

                var totalCount = await hospitalsQuery.LongCountAsync();

                var items = await hospitalsQuery.Select(x => new HealthBankListItemDTO
                {
                    Type = type,
                    Id = x.Id,
                    Name = lang == Lang.EN ? x.Name : lang == Lang.AR ? x.Name_Ar : x.Name_Ku,
                    Address = lang == Lang.EN ? x.Address : lang == Lang.AR ? x.Address_Ar : x.Address_Ku,
                    Icon = !string.IsNullOrEmpty(x.Logo) ? $"{hostAddress}{x.Logo}" : $"{hostAddress}/images/centers/hospital/hospital.png",
                    City = lang == Lang.EN ? x.City.Name : lang == Lang.AR ? x.City.Name_Ar : x.City.Name_Ku
                }).Skip(pageSize * page).Take(pageSize).ToListAsync();

                return new HealthBankItemsPagingResultDTO
                {
                    TotalCount = totalCount,
                    Items = items
                };
            }
            else if (type == HealthBankCategoryType.CLINIC)
            {
                IQueryable<Clinic> clinicsQuery = _dbContext.Clinics;

                if (cityId != null) clinicsQuery = clinicsQuery.Where(x => x.CityId == cityId);

                if (!string.IsNullOrEmpty(filterString)) clinicsQuery.Where(x => x.Name.Contains(filterString) || x.Name_Ku.Contains(filterString) || x.Name_Ar.Contains(filterString));

                var totalCount = await clinicsQuery.LongCountAsync();

                var items = await clinicsQuery.Select(x => new HealthBankListItemDTO
                {
                    Type = type,
                    Id = x.Id,
                    Name = lang == Lang.EN ? x.Name : lang == Lang.AR ? x.Name_Ar : x.Name_Ku,
                    Address = lang == Lang.EN ? x.Address : lang == Lang.AR ? x.Address_Ar : x.Address_Ku,
                    Icon = !string.IsNullOrEmpty(x.Logo) ? $"{hostAddress}{x.Logo}" : $"{hostAddress}/images/centers/clinic/clinic.png",
                    City = lang == Lang.EN ? x.City.Name : lang == Lang.AR ? x.City.Name_Ar : x.City.Name_Ku,
                }).Skip(pageSize * page).Take(pageSize).ToListAsync();

                return new HealthBankItemsPagingResultDTO
                {
                    TotalCount = totalCount,
                    Items = items
                };
            }
            else
            {
                IQueryable<ShiftCenter> centersQuery = _dbContext.ShiftCenters.Where(x => x.IsApproved && x.IsIndependent && x.ShowInHealthBank && x.Type.HasFlag(centerType));

                if (cityId != null) centersQuery = centersQuery.Where(x => x.CityId == cityId);

                if (!string.IsNullOrEmpty(filterString)) centersQuery.Where(x => x.Name.Contains(filterString) || x.Name_Ku.Contains(filterString) || x.Name_Ar.Contains(filterString));

                var totalCount = await centersQuery.LongCountAsync();

                var items = await centersQuery.Select(x => new HealthBankListItemDTO
                {
                    Type = type,
                    Id = x.Id,
                    Name = lang == Lang.EN ? x.Name : lang == Lang.AR ? x.Name_Ar : x.Name_Ku,
                    Address = lang == Lang.EN ? x.Address : lang == Lang.AR ? x.Address_Ar : x.Address_Ku,
                    CenterType = (int)x.Type,
                    Icon = !string.IsNullOrEmpty(x.Logo) ? $"{hostAddress}{x.Logo}" : $"{hostAddress}/images/centers/{x.Type.GetCenterTypeIconsFolderName()}/{x.Type.GetCenterTypeIconsFolderName()}.png",
                    City = lang == Lang.EN ? x.City.Name : lang == Lang.AR ? x.City.Name_Ar : x.City.Name_Ku,
                }).Skip(pageSize * page).Take(pageSize).ToListAsync();

                return new HealthBankItemsPagingResultDTO
                {
                    TotalCount = totalCount,
                    Items = items
                };
            }
        }

        public async Task<HealthBankItemDetailDTO> GetHealthBankItemDetailAsync(HealthBankCategoryType type, Lang lang, string hostAddress, int id)
        {
            if (type == HealthBankCategoryType.HOSPITAL)
            {
                var hospital = await _dbContext.Hospitals.FindAsync(id);

                if (hospital == null) throw new AwroNoreException("Hospital not found");

                var images = await _dbContext.Attachments.Where(x => x.Owner == FileOwner.HOSPITAL && x.OwnerTableId == hospital.Id && x.FileType == FileType.Image).Select(x => new ImageUrlModel
                {
                    Url = x.Url,
                    ThumbUrl = x.ThumbnailUrl
                }).ToListAsync();

                var result = new HealthBankItemDetailDTO
                {
                    Type = type,
                    Id = hospital.Id,
                    Name = lang == Lang.EN ? hospital.Name : lang == Lang.AR ? hospital.Name_Ar : hospital.Name_Ku,
                    Address = lang == Lang.EN ? hospital.Address : lang == Lang.AR ? hospital.Address_Ar : hospital.Address_Ku,
                    Icon = !string.IsNullOrEmpty(hospital.Logo) ? $"{hostAddress}{hospital.Logo}" : $"{hostAddress}/images/centers/hospital/hospital.png",
                    City = lang == Lang.EN ? hospital.City.Name : lang == Lang.AR ? hospital.City.Name_Ar : hospital.City.Name_Ku,
                    Latitude = hospital.Location?.Y ?? 0,
                    Longitude = hospital.Location?.X ?? 0,
                    Description = lang == Lang.EN ? hospital.Description : lang == Lang.AR ? hospital.Description_Ar : hospital.Description_Ku,
                    Phone = hospital.PhoneNumbers != null &&  hospital.PhoneNumbers.Any() ? hospital.PhoneNumbers.FirstOrDefault().PhoneNumber : "",
                    Annoucement = lang == Lang.EN ? hospital.Notification : lang == Lang.AR ? hospital.Notification_Ar : hospital.Notification_Ku,
                    Images = images
                };

                return result;
            }
            else if (type == HealthBankCategoryType.CLINIC)
            {
                var clinic = await _dbContext.Clinics.FindAsync(id);

                if (clinic == null) throw new AwroNoreException("Clinic not found");

                var images = await _dbContext.Attachments.Where(x => x.Owner == FileOwner.CLINIC && x.OwnerTableId == clinic.Id && x.FileType == FileType.Image).Select(x => new ImageUrlModel
                {
                    Url = x.Url,
                    ThumbUrl = x.ThumbnailUrl
                }).ToListAsync();

                var result = new HealthBankItemDetailDTO
                {
                    Type = type,
                    Id = clinic.Id,
                    Name = lang == Lang.EN ? clinic.Name : lang == Lang.AR ? clinic.Name_Ar : clinic.Name_Ku,
                    Address = lang == Lang.EN ? clinic.Address : lang == Lang.AR ? clinic.Address_Ar : clinic.Address_Ku,
                    Icon = !string.IsNullOrEmpty(clinic.Logo) ? $"{hostAddress}{clinic.Logo}" : $"{hostAddress}/images/centers/clinic/clinic.png",
                    City = lang == Lang.EN ? clinic.City.Name : lang == Lang.AR ? clinic.City.Name_Ar : clinic.City.Name_Ku,
                    Latitude = clinic.Location?.Y ?? 0,
                    Longitude = clinic.Location?.X ?? 0,
                    Description = lang == Lang.EN ? clinic.Description : lang == Lang.AR ? clinic.Description_Ar : clinic.Description_Ku,
                    Phone = clinic.PhoneNumbers != null && clinic.PhoneNumbers.Any() ? clinic.PhoneNumbers.FirstOrDefault().PhoneNumber : "",
                    Annoucement = lang == Lang.EN ? clinic.Notification : lang == Lang.AR ? clinic.Notification_Ar : clinic.Notification_Ku,
                    Images = images
                };

                return result;
            }
            else
            {
                var center = await _dbContext.ShiftCenters.FindAsync(id);

                if (center == null) throw new AwroNoreException("Center not found");

                var images = await _dbContext.Attachments.Where(x => x.Owner == FileOwner.SHIFT_CENTER && x.OwnerTableId == center.Id && x.FileType == FileType.Image).Select(x => new ImageUrlModel
                {
                    Url = x.Url,
                    ThumbUrl = x.ThumbnailUrl
                }).ToListAsync();

                var result = new HealthBankItemDetailDTO
                {
                    Type = type,
                    Id = center.Id,
                    Name = lang == Lang.EN ? center.Name : lang == Lang.AR ? center.Name_Ar : center.Name_Ku,
                    Address = lang == Lang.EN ? center.Address : lang == Lang.AR ? center.Address_Ar : center.Address_Ku,
                    Icon = !string.IsNullOrEmpty(center.Logo) ? $"{hostAddress}{center.Logo}" : $"{hostAddress}/images/centers/{center.Type.GetCenterTypeIconsFolderName()}/{center.Type.GetCenterTypeIconsFolderName()}.png",
                    City = lang == Lang.EN ? center.City.Name : lang == Lang.AR ? center.City.Name_Ar : center.City.Name_Ku,
                    CenterType = (int)center.Type,
                    Latitude = center.Location?.Y ?? 0,
                    Longitude = center.Location?.X ?? 0,
                    Description = lang == Lang.EN ? center.Description : lang == Lang.AR ? center.Description_Ar : center.Description_Ku,
                    Phone = center.PhoneNumbers != null && center.PhoneNumbers.Any() ? center.PhoneNumbers.FirstOrDefault().PhoneNumber : "",
                    Annoucement = lang == Lang.EN ? center.Notification : lang == Lang.AR ? center.Notification_Ar : center.Notification_Ku,
                    Images = images
                };

                return result;
            }
        }
    }
}

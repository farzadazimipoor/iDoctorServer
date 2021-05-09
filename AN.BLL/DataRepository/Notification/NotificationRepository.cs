using AN.Core.Data;
using AN.Core.Domain;
using AN.Core.DTO;
using AN.Core.Enums;
using AN.Core.ViewModels;
using Microsoft.EntityFrameworkCore;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AN.BLL.DataRepository
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly IRepository<Notification> _repository;
        private readonly IRepository<Person> _personRepository;
        public NotificationRepository(IRepository<Notification> repository, IRepository<Person> personRepository)
        {
            _repository = repository;
            _personRepository = personRepository;
        }

        public async Task<NotificationsResultDTO> GetMyNotifications(Lang lng, string mobile = "")
        {
            var query = _repository.Table;

            if (!string.IsNullOrEmpty(mobile))
            {
                var person = await _personRepository.Table.Where(x => x.Mobile == mobile).FirstOrDefaultAsync();

                if (person == null) return new NotificationsResultDTO
                {
                    TotalCount = 0,
                    Notifications = new List<NotificationListItemDTO>()
                };

                query = query.Where(x => x.PersonId == person.Id || x.PersonId == null);
            }
            else
            {
                query = query.Where(x => x.PersonId == null);
            }

            var totalCount = await query.CountAsync();

            var notifications = await query.OrderByDescending(x => x.CreatedAt).Select(x => new NotificationListItemDTO
            {
                Id = x.Id,
                Title = x.Title,                
                TitleKu = x.Title_Ku,                
                TitleAr = x.Title_Ar,                
                Text = x.Text,
                TextKu = x.Text_Ku,
                TextAr = x.Text_Ar,
                Description = x.Description,
                DescriptionKu = x.Description_Ku,
                DescriptionAr = x.Description_Ar,
                PayloadJson = x.PayloadJson,
                Image = x.Image,
                CreatedAt = x.CreatedAt,
                IsExpired = DateTime.Now > x.ValidUntil
            }).ToListAsync();

            var result = new NotificationsResultDTO
            {
                TotalCount = totalCount,
                Notifications = notifications
            };

            return result;
        }

        public async Task<DataTablesPagedResults<NotificationViewModel>> GetDataTableAsync(DataTablesParameters table, NotificationFilterViewModel filters, Lang lng = Lang.KU)
        {
            IQueryable<Notification> query = _repository.Table;

            if (!string.IsNullOrEmpty(filters.FilterString))
            {
                var mobileWithoutZero = "";
                var isNumeric = double.TryParse(filters.FilterString, out _);
                if (isNumeric)
                {
                    if (filters.FilterString.Length > 10)
                    {
                        mobileWithoutZero = filters.FilterString.Substring(filters.FilterString.Length - 10);
                    }
                }
                query = query.Where(x => x.Title.Contains(filters.FilterString) || x.Title_Ku.Contains(filters.FilterString) || x.Title_Ar.Contains(filters.FilterString) ||
                                         x.Text.Contains(filters.FilterString) || x.Text_Ku.Contains(filters.FilterString) || x.Text_Ar.Contains(filters.FilterString) ||
                                         x.Description.Contains(filters.FilterString) || x.Description_Ku.Contains(filters.FilterString) || x.Description_Ar.Contains(filters.FilterString));
            }

            if (filters.FromDate != null)
            {
                query = query.Where(a => a.CreatedAt >= filters.FromDate);
            }

            if (filters.ToDate != null)
            {
                filters.ToDate = DateTime.Parse($"{filters.ToDate.Value.ToShortDateString()} 23:59:59");

                query = query.Where(a => a.CreatedAt <= filters.ToDate);
            }

            if (table.Order != null && table.Order.Any())
            {
                var orderIndex = table.Order[0].Column;
                var orderDir = table.Order[0].Dir;

                if (orderIndex == 1)
                {
                    query = orderDir == DataTablesOrderDir.DESC ? query.OrderByDescending(x => lng == Lang.EN ?  x.Title : lng == Lang.AR ? x.Title_Ar : x.Title_Ku) : query.OrderBy(x => lng == Lang.EN ? x.Title : lng == Lang.AR ? x.Title_Ar : x.Title_Ku);
                }
                else if (orderIndex == 2)
                {
                    query = orderDir == DataTablesOrderDir.DESC ? query.OrderByDescending(x => x.CreatedAt) : query.OrderBy(x => x.CreatedAt);
                }
                else if (orderIndex == 3)
                {
                    query = orderDir == DataTablesOrderDir.DESC ? query.OrderByDescending(x => x.ValidUntil) : query.OrderBy(x => x.ValidUntil);
                }
            }
            else
            {
                query = query.OrderByDescending(x => x.CreatedAt);
            }

            var size = await query.CountAsync();

            var items = await query
                .AsNoTracking()
                .Skip((table.Start / table.Length) * table.Length)
                .Take(table.Length)
                .Select(x => new NotificationViewModel
                {
                    Id = x.Id,
                    Title = lng == Lang.EN ? x.Title : lng == Lang.AR ? x.Title_Ar : x.Title_Ku,
                    CreateDate = x.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss"),
                    ValidUntil = x.ValidUntil.ToString("yyyy-MM-dd"),
                })
                .ToListAsync();

            return new DataTablesPagedResults<NotificationViewModel>
            {
                Items = items,
                TotalSize = size
            };
        }
    }
}

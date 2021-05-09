using AN.Core.Data;
using AN.Core.Domain;
using AN.Core.Enums;
using AN.Core.Exceptions;
using AN.Core.ViewModels;
using Microsoft.EntityFrameworkCore;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AN.BLL.DataRepository
{
    public class ConsultancyRepository : IConsultancyRepository
    {
        private readonly IRepository<Consultancy> _repository;
        private readonly IRepository<ConsultancyMessage> _messageRepository;
        public ConsultancyRepository(IRepository<Consultancy> repository, IRepository<ConsultancyMessage> messageRepository)
        {
            _repository = repository;
            _messageRepository = messageRepository;
        }

        public async Task<DataTablesPagedResults<ConsultancyChatsListViewModel>> GetDataTableAsync(DataTablesParameters table, ConsultancyChatsFilterViewModel filters, Lang lng = Lang.KU)
        {
            IQueryable<Consultancy> query = _repository.Table;

            if (filters.ServiceSupplyId != null)
            {
                query = query.Where(x => x.ServiceSupplyId == filters.ServiceSupplyId);
            }

            if (filters.PersonId != null)
            {
                query = query.Where(x => x.PersonId == filters.PersonId);
            }

            if (filters.Status != null)
            {
                query = query.Where(x => x.Status == filters.Status);
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

            if (!string.IsNullOrEmpty(filters.FilterString))
            {
                query = query.Where(x => x.Person.FullName.Contains(filters.FilterString) || x.Person.FullName_Ku.Contains(filters.FilterString) || x.Person.FullName_Ar.Contains(filters.FilterString) ||
                                         x.ServiceSupply.Person.FullName.Contains(filters.FilterString) || x.ServiceSupply.Person.FullName_Ku.Contains(filters.FilterString) || x.ServiceSupply.Person.FullName_Ar.Contains(filters.FilterString));
            }

            if (table.Order != null && table.Order.Any())
            {
                var orderIndex = table.Order[0].Column;
                var orderDir = table.Order[0].Dir;

                if (orderIndex == 1)
                {
                    query = orderDir == DataTablesOrderDir.DESC ? query.OrderByDescending(x => x.ServiceSupplyId) : query.OrderBy(x => x.ServiceSupplyId);
                }
                else if (orderIndex == 2)
                {
                    query = orderDir == DataTablesOrderDir.DESC ? query.OrderByDescending(x => x.PersonId) : query.OrderBy(x => x.PersonId);
                }
                else if (orderIndex == 3)
                {
                    query = orderDir == DataTablesOrderDir.DESC ? query.OrderByDescending(x => x.Status) : query.OrderBy(x => x.Status);
                }
                else if (orderIndex == 4)
                {
                    query = orderDir == DataTablesOrderDir.DESC ? query.OrderByDescending(x => x.CreatedAt) : query.OrderBy(x => x.CreatedAt);
                }
                else if (orderIndex == 5)
                {
                    query = orderDir == DataTablesOrderDir.DESC ? query.OrderByDescending(x => x.StartedAt) : query.OrderBy(x => x.StartedAt);
                }
                else if (orderIndex == 6)
                {
                    query = orderDir == DataTablesOrderDir.DESC ? query.OrderByDescending(x => x.FinishedAt) : query.OrderBy(x => x.FinishedAt);
                }
                else if (orderIndex == 7)
                {
                    query = orderDir == DataTablesOrderDir.DESC ? query.OrderByDescending(x => x.ConsultancyMessages.Count) : query.OrderBy(x => x.ConsultancyMessages.Count);
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
                .Select(x => new ConsultancyChatsListViewModel
                {
                    Id = x.Id,
                    Doctor = lng == Lang.EN ? x.ServiceSupply.Person.FullName : lng == Lang.AR ? x.ServiceSupply.Person.FullName_Ar : x.ServiceSupply.Person.FullName_Ku,
                    Patient = lng == Lang.EN ? x.Person.FullName : lng == Lang.AR ? x.Person.FullName_Ar : x.Person.FullName_Ku,
                    CreateDate = x.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss"),
                    StartDate = x.StartedAt != null ? x.StartedAt.Value.ToString("yyyy-MM-dd HH:mm:ss") : "",
                    FinishDate = x.FinishedAt != null ? x.FinishedAt.Value.ToString("yyyy-MM-dd HH:mm:ss") : "",
                    MessagesCount = x.ConsultancyMessages.Count(),
                    Status = x.Status.ToString()
                })
                .ToListAsync();

            return new DataTablesPagedResults<ConsultancyChatsListViewModel>
            {
                Items = items,
                TotalSize = size
            };
        }

        public async Task<(ChatDetailsViewModel chatDetails, List<MessageItemViewModel> messages)> GetChatMessagesAsync(int chatId)
        {
            var chat = await _repository.GetByIdAsync(chatId);

            if (chat == null) throw new AwroNoreException("Chat not found");

            var details = new ChatDetailsViewModel
            {
                Doctor = chat.ServiceSupply.Person.FullName,
                DoctorAvatar = chat.ServiceSupply.Person.RealAvatar,
                Person = chat.Person.FullName,
                PersonAvatar = chat.Person.RealAvatar,
                MessagesCount = chat.ConsultancyMessages.Count,
                Date = chat.CreatedAt.ToString("yyyy-MM-dd HH:mm"),
                Status = chat.Status
            };

            var messages = await _messageRepository.Table.Where(x => x.ConsultancyId == chatId).OrderBy(x => x.CreatedAt).Select(x => new MessageItemViewModel
            {
                Doctor = x.ServiceSupply.Person.FullName,
                Person = x.Person.FullName,
                Time = x.CreatedAt.ToString("yyyy-MM-dd HH:mm"),
                DoctorAvatar = x.ServiceSupply.Person.RealAvatar,
                PersonAvatar = x.Person.RealAvatar,
                Content = x.Content,
                Sender = x.Sender,
                Status = x.Status,
                Type = x.Type
            }).ToListAsync();

            return (details, messages);
        }
    }
}

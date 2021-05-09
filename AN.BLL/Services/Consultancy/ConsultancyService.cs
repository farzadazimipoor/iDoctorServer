using AN.BLL.Core.Services.Messaging.Notifications;
using AN.BLL.Extensions;
using AN.BLL.Services.Upload;
using AN.Core.Domain;
using AN.Core.DTO.Consultancy;
using AN.Core.Enums;
using AN.Core.Exceptions;
using AN.Core.MyComparers;
using AN.Core.Resources.Global;
using AN.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Shared.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AN.BLL.Services
{
    public class ConsultancyService : IConsultancyService
    {
        private readonly BanobatDbContext _dbContext;
        private readonly INotificationService _notificationService;
        private readonly IUploadService _uploadService;
        private readonly IOptions<AppSettings> _options;
        public ConsultancyService(BanobatDbContext dbContext, INotificationService notificationService, IUploadService uploadService, IOptions<AppSettings> options)
        {
            _dbContext = dbContext;
            _notificationService = notificationService;
            _uploadService = uploadService;
            _options = options;
        }

        public async Task<List<ConsultancyDoctorItemDTO>> GetTopConsultancyDoctorsAsync(Lang lang)
        {
            IQueryable<ServiceSupply> query = _dbContext.ServiceSupplies.Include(x => x.DoctorExpertises);

            query = query.Where(x => x.ConsultancyEnabled);

            query = query.OrderByDescending(x => x.Consultancies.Count(c => c.Status == ConsultancyStatus.STARTED)).Take(20);

            var doctors = await (from x in query
                                 select new ConsultancyDoctorItemDTO
                                 {
                                     Id = x.Id,
                                     FullName = lang == Lang.KU ? x.Person.FullName_Ku : lang == Lang.AR ? x.Person.FullName_Ar : x.Person.FullName,
                                     Avatar = x.Person.RealAvatar,
                                     AverageRating = x.AverageRating != null ? (double)Math.Round((decimal)x.AverageRating, 2) : 5,
                                     Speciality = x.DoctorExpertises.Any() ? lang == Lang.KU ? _dbContext.ExpertiseCategories.FirstOrDefault(e => e.Expertises.Any(a => a.DoctorExpertises.Any(u => u.ServiceSupplyId == x.Id))).Name_Ku : lang == Lang.AR ? _dbContext.ExpertiseCategories.FirstOrDefault(e => e.Expertises.Any(a => a.DoctorExpertises.Any(u => u.ServiceSupplyId == x.Id))).Name_Ar : _dbContext.ExpertiseCategories.FirstOrDefault(e => e.Expertises.Any(a => a.DoctorExpertises.Any(u => u.ServiceSupplyId == x.Id))).Name : "",
                                     Questions = x.Consultancies.Count(c => c.Status == ConsultancyStatus.STARTED)
                                 }).ToListAsync();

            return doctors;

        }

        public async Task<ConsultancyGroupsResultDTO> GetConsultancyGroupsAsync(Lang lang)
        {
            IQueryable<ExpertiseCategory> query = _dbContext.ExpertiseCategories;

            var totalCount = await query.CountAsync();

            var groups = await query.OrderBy(x => x.CreatedAt).Select(x => new ConsultancyGroupDTO
            {
                Id = x.Id,
                Title = lang == Lang.AR ? x.Name_Ar : lang == Lang.KU ? x.Name_Ku : x.Name,
                Doctors = _dbContext.DoctorExpertises.Where(de => de.Expertise.ExpertiseCategoryId == x.Id && de.ServiceSupply.ConsultancyEnabled).Select(s => new ConsultancyGroupDoctorDTO
                {
                    Id = s.ServiceSupplyId,
                    Fullname = lang == Lang.AR ? s.ServiceSupply.Person.FullName_Ar : lang == Lang.KU ? s.ServiceSupply.Person.FullName_Ku : s.ServiceSupply.Person.FullName,
                    Avatar = s.ServiceSupply.Person.RealAvatar
                }).ToList()
            }).ToListAsync();

            groups.ForEach(x => x.Doctors = x.Doctors.Distinct(new ConsultancyGroupDoctorComprarer()).ToList());

            return new ConsultancyGroupsResultDTO
            {
                TotalCount = totalCount,
                ConsultancyGroups = groups
            };
        }

        public async Task<ConsultancyDoctorsResultDTO> GetConsultancyGroupDoctorsAsync(int expertiseCategoryId, Lang lang, int page = 0, int pageSize = 12, string userMobile = "")
        {
            Person person = null;

            if (!string.IsNullOrEmpty(userMobile))
            {
                person = await _dbContext.Persons.FirstOrDefaultAsync(x => x.Mobile == userMobile);
            }

            IQueryable<ServiceSupply> query = _dbContext.ServiceSupplies;

            query = query.Where(x => x.ConsultancyEnabled);

            query = query.Where(x => x.DoctorExpertises.Any(de => de.Expertise.ExpertiseCategoryId == expertiseCategoryId));

            var totalCount = await query.CountAsync();

            var doctors = await query.OrderByDescending(x => x.Consultancies.Count(c => c.Status == ConsultancyStatus.STARTED)).Skip(pageSize * page).Take(pageSize).Select(x => new ConsultancyDoctorChatItemDTO
            {
                Id = x.Id,
                FullName = lang == Lang.KU ? x.Person.FullName_Ku : lang == Lang.AR ? x.Person.FullName_Ar : x.Person.FullName,
                Avatar = x.Person.RealAvatar,
                AverageRating = x.AverageRating != null ? (double)Math.Round((decimal)x.AverageRating, 2) : 5,
                Speciality = x.DoctorExpertises.Any() ? (lang == Lang.KU ? _dbContext.ExpertiseCategories.FirstOrDefault(e => e.Expertises.Any(a => a.DoctorExpertises.Any(u => u.ServiceSupplyId == x.Id))).Name_Ku : lang == Lang.AR ? _dbContext.ExpertiseCategories.FirstOrDefault(e => e.Expertises.Any(a => a.DoctorExpertises.Any(u => u.ServiceSupplyId == x.Id))).Name_Ar : _dbContext.ExpertiseCategories.FirstOrDefault(e => e.Expertises.Any(a => a.DoctorExpertises.Any(u => u.ServiceSupplyId == x.Id))).Name) : "",
                Questions = x.Consultancies.Count(c => c.Status == ConsultancyStatus.STARTED),
                LastMessage = "",
                LastMessageTime = "",
                HasUnSeenMessages = false,
                Seen = true,
                IsOnline = false,
                UnSeenCount = 0
            }).ToListAsync();

            var result = new ConsultancyDoctorsResultDTO
            {
                TotalCount = totalCount,
                ConsultancyDoctors = doctors
            };

            return result;
        }

        public async Task<UserConsultancyDetailsDTO> GetUserConsultancyDetailsAsync(string userMobile, int serviceSupplyId, Lang lang)
        {
            var person = await _dbContext.Persons.FirstOrDefaultAsync(x => x.Mobile == userMobile);

            if (person == null) throw new AwroNoreException("Not any person found for this mobile number");

            var query = _dbContext.Consultancies.Where(x => x.ServiceSupplyId == serviceSupplyId && x.PersonId == person.Id);

            var totalCount = await query.CountAsync();

            var finishedCount = await query.CountAsync(x => x.FinishedAt != null);

            var currentOpenChat = await query.Where(x => x.Status != ConsultancyStatus.FINISHED && x.Status != ConsultancyStatus.REMOVED_BY_DOCTOR).FirstOrDefaultAsync();

            var result = new UserConsultancyDetailsDTO
            {
                PersonId = person.Id,
                ServiceSupplyId = serviceSupplyId,
                TotalChatsCount = totalCount,
                FinishedChatsCount = finishedCount,
                CurrentChatId = currentOpenChat?.Id
            };

            return result;
        }

        public async Task<ConsultancyChatDTO> GetOrCreateNewChatMessagesAsync(int serviceSupplyId, string userMobile, Lang lang, int? currentChatId = null)
        {
            var person = await _dbContext.Persons.FirstOrDefaultAsync(x => x.Mobile == userMobile);

            if (person == null) throw new AwroNoreException("Not any person found for this mobile number");

            var appSettings = _options.Value.AwroNoreSettings;

            var chatscreenMention = lang == Lang.KU ? appSettings.ChatScreenMention.MentionKu : lang == Lang.AR ? appSettings.ChatScreenMention.MentionAr : appSettings.ChatScreenMention.Mention;

            var consultantStatus = lang == Lang.KU ? appSettings.ConsultantDefaultStatus.StatusKu : lang == Lang.AR ? appSettings.ConsultantDefaultStatus.StatusAr : appSettings.ConsultantDefaultStatus.Status;

            if (currentChatId != null)
            {
                var currentChat = await _dbContext.Consultancies.FindAsync(currentChatId.Value);

                if (currentChat == null) throw new AwroNoreException("This chat is no longer available");

                if (currentChat.ServiceSupplyId != serviceSupplyId) throw new AwroNoreException("Current chat contact is wrong");

                var form = await _dbContext.DiseaseRecordsForms.FirstOrDefaultAsync(x => x.PersonId == currentChat.PersonId);

                var result = new ConsultancyChatDTO
                {
                    Id = currentChat.Id,
                    Status = currentChat.Status != ConsultancyStatus.REMOVED_BY_DOCTOR ? currentChat.Status : ConsultancyStatus.FINISHED,
                    ChatScreenMention = chatscreenMention,
                    ContactStatus = consultantStatus,
                    Messages = currentChat.ConsultancyMessages.Select(x => new ConsultancyMessageDTO
                    {
                        Id = x.Id,
                        SenderReceiverType = x.Sender == ConsultancyMessageSender.CUSTOMER ? MessageSenderReceiverType.SENT : MessageSenderReceiverType.RECEIVED,
                        ContactName = x.Sender == ConsultancyMessageSender.CUSTOMER ? (lang == Lang.KU ? x.Person.FullName_Ku : lang == Lang.AR ? x.Person.FullName_Ar : x.Person.FullName) : (lang == Lang.KU ? x.ServiceSupply.Person.FullName_Ku : lang == Lang.AR ? x.ServiceSupply.Person.FullName_Ar : x.ServiceSupply.Person.FullName),
                        ContactAvatar = x.Sender == ConsultancyMessageSender.CUSTOMER ? x.Person.RealAvatar : x.ServiceSupply.Person.RealAvatar,
                        Message = x.Content,
                        Time = x.CreatedAt.ToString("HH:mm"),
                        Type = x.Type,
                    }).ToList(),
                    DiseaseRecordsForm = form == null ? null : new AN.Core.DTO.Profile.DiseaseRecordsFormDTO
                    {
                        Age = form.Age,
                        DoYouSmoke = form.DoYouSmoke,
                        DrugsYouUsed = form.DrugsYouUsed,
                        HadSurgery = form.HadSurgery,
                        HasLongTermDisease = form.HasLongTermDisease,
                        LongTermDiseasesDescription = form.LongTermDiseasesDescription,
                        MedicalAllergies = form.MedicalAllergies,
                        PersonId = person.Id,
                        SurgeriesDescription = form.SurgeriesDescription
                    }
                };

                return result;
            }
            // Create new consultancy
            else
            {
                var notFinishedChat = await _dbContext.Consultancies.FirstOrDefaultAsync(x => x.ServiceSupplyId == serviceSupplyId && x.PersonId == person.Id && x.Status != ConsultancyStatus.FINISHED && x.Status != ConsultancyStatus.REMOVED_BY_DOCTOR);

                if (notFinishedChat != null)
                {
                    var form = await _dbContext.DiseaseRecordsForms.FirstOrDefaultAsync(x => x.PersonId == notFinishedChat.PersonId); 

                    var result = new ConsultancyChatDTO
                    {
                        Id = notFinishedChat.Id,
                        Status = notFinishedChat.Status != ConsultancyStatus.REMOVED_BY_DOCTOR ? notFinishedChat.Status : ConsultancyStatus.FINISHED,
                        ChatScreenMention = chatscreenMention,
                        ContactStatus = consultantStatus,
                        Messages = notFinishedChat.ConsultancyMessages.Select(x => new ConsultancyMessageDTO
                        {
                            Id = x.Id,
                            SenderReceiverType = x.Sender == ConsultancyMessageSender.CUSTOMER ? MessageSenderReceiverType.SENT : MessageSenderReceiverType.RECEIVED,
                            ContactName = x.Sender == ConsultancyMessageSender.CUSTOMER ? x.Person.FullName : x.ServiceSupply.Person.FullName,
                            ContactAvatar = x.Sender == ConsultancyMessageSender.CUSTOMER ? x.Person.RealAvatar : x.ServiceSupply.Person.RealAvatar,
                            Message = x.Content,
                            Time = x.CreatedAt.ToString("HH:mm"),
                            Type = x.Type,
                        }).ToList(),
                        DiseaseRecordsForm = form == null ? null : new AN.Core.DTO.Profile.DiseaseRecordsFormDTO
                        {
                            Age = form.Age,
                            DoYouSmoke = form.DoYouSmoke,
                            DrugsYouUsed = form.DrugsYouUsed,
                            HadSurgery = form.HadSurgery,
                            HasLongTermDisease = form.HasLongTermDisease,
                            LongTermDiseasesDescription = form.LongTermDiseasesDescription,
                            MedicalAllergies = form.MedicalAllergies,
                            PersonId = person.Id,
                            SurgeriesDescription = form.SurgeriesDescription
                        }
                    };

                    return result;
                }
                else
                {
                    var consultancy = new Consultancy
                    {
                        PersonId = person.Id,
                        ServiceSupplyId = serviceSupplyId,
                        CreatedAt = DateTime.Now,
                        Status = ConsultancyStatus.NEW
                    };

                    await _dbContext.Consultancies.AddAsync(consultancy);

                    await _dbContext.SaveChangesAsync();

                    var form = await _dbContext.DiseaseRecordsForms.FirstOrDefaultAsync(x => x.PersonId == consultancy.PersonId);

                    var result = new ConsultancyChatDTO
                    {
                        Id = consultancy.Id,
                        ChatScreenMention = chatscreenMention,
                        ContactStatus = consultantStatus,
                        Messages = new List<ConsultancyMessageDTO>(),
                        DiseaseRecordsForm = form == null ? null : new AN.Core.DTO.Profile.DiseaseRecordsFormDTO
                        {
                            Age = form.Age,
                            DoYouSmoke = form.DoYouSmoke,
                            DrugsYouUsed = form.DrugsYouUsed,
                            HadSurgery = form.HadSurgery,
                            HasLongTermDisease = form.HasLongTermDisease,
                            LongTermDiseasesDescription = form.LongTermDiseasesDescription,
                            MedicalAllergies = form.MedicalAllergies,
                            PersonId = person.Id,
                            SurgeriesDescription = form.SurgeriesDescription
                        }
                    };

                    return result;
                }
            }
        }

        public async Task<ConsultancyMessageDTO> SendConsultancyMessageAsync(SendMessageDTO model)
        {
            ConsultancyMessageDTO result = null;

            var strategy = _dbContext.Database.CreateExecutionStrategy();

            await strategy.ExecuteAsync(async () =>
            {
                using (var transaction = _dbContext.Database.BeginTransaction())
                {
                    var msg = new ConsultancyMessage
                    {
                        ConsultancyId = model.ConsultancyId,
                        ServiceSupplyId = model.ServiceSupplyId,
                        PersonId = model.PersonId,
                        CreatedAt = DateTime.Now,
                        Content = model.Content,
                        Status = ConsultancyMessageStatus.NEW,
                        Sender = model.Sender,
                        Type = model.Type,
                    };

                    await _dbContext.ConsultancyMessages.AddAsync(msg);

                    await _dbContext.SaveChangesAsync();

                    result = new ConsultancyMessageDTO
                    {
                        Id = msg.Id,
                        SenderReceiverType = msg.Sender == ConsultancyMessageSender.CUSTOMER ? MessageSenderReceiverType.SENT : MessageSenderReceiverType.RECEIVED,
                        Message = msg.Content,
                        Time = msg.CreatedAt.ToString("HH:mm"),
                        Type = msg.Type
                    };

                    transaction.Commit();
                }
            });

            await NotifyMessageReceiverAsync(model, result);

            return result ?? throw new AwroNoreException("");
        }

        public async Task<ConsultancyMessageDTO> SendMultiMediaMessageAsync(SendMessageDTO model, IFormFile file)
        {
            ConsultancyMessageDTO result = null;

            var strategy = _dbContext.Database.CreateExecutionStrategy();

            await strategy.ExecuteAsync(async () =>
            {
                using (var transaction = _dbContext.Database.BeginTransaction())
                {
                    var msg = new ConsultancyMessage
                    {
                        ConsultancyId = model.ConsultancyId,
                        ServiceSupplyId = model.ServiceSupplyId,
                        PersonId = model.PersonId,
                        CreatedAt = DateTime.Now,
                        Content = "",
                        Status = ConsultancyMessageStatus.NEW,
                        Sender = model.Sender,
                        Type = model.Type,
                    };

                    await _dbContext.ConsultancyMessages.AddAsync(msg);

                    await _dbContext.SaveChangesAsync();

                    if (model.Type == ConsultancyMessageType.PHOTO)
                    {
                        var (newName, thumbName, dirPath, baseUrl) = _uploadService.GenerateConsultancyMessageImageName(model.ConsultancyId, msg.Id, file);

                        var url = $"{baseUrl}/{newName}";

                        var thumbUrl = $"{baseUrl}/{thumbName}";

                        msg.Content = $"{url},{thumbUrl}";

                        _dbContext.ConsultancyMessages.Attach(msg);

                        _dbContext.Entry(msg).State = EntityState.Modified;

                        await _dbContext.SaveChangesAsync();

                        await _uploadService.UploadConsultancyMessageImageAsync(file, dirPath, newName, thumbName);
                    }
                    else if (model.Type == ConsultancyMessageType.VOICE)
                    {
                        var (newName, dirPath, baseUrl) = _uploadService.GenerateConsultancyMessageVoiceName(model.ConsultancyId, msg.Id, file);

                        var url = $"{baseUrl}/{newName}";

                        msg.Content = $"{url}";

                        _dbContext.ConsultancyMessages.Attach(msg);

                        _dbContext.Entry(msg).State = EntityState.Modified;

                        await _dbContext.SaveChangesAsync();

                        await _uploadService.UploadConsultancyMessageVoiceAsync(file, dirPath, newName);
                    }

                    result = new ConsultancyMessageDTO
                    {
                        Id = msg.Id,
                        SenderReceiverType = msg.Sender == ConsultancyMessageSender.CUSTOMER ? MessageSenderReceiverType.SENT : MessageSenderReceiverType.RECEIVED,
                        Message = msg.Content,
                        Time = msg.CreatedAt.ToString("HH:mm"),
                        Type = msg.Type
                    };

                    transaction.Commit();
                }
            });

            await NotifyMessageReceiverAsync(model, result);

            return result ?? throw new AwroNoreException("");
        }

        private async Task NotifyMessageReceiverAsync(SendMessageDTO model, ConsultancyMessageDTO result)
        {
            try
            {
                var instanceIds = new List<string>();
                var doctorName = "";
                var doctorAvatar = "";
                var customerName = "";
                var customerAvatar = "";
                var personName = "";
                var personAvatar = "";
                // Receiver is doctor, so we must send notification to doctor
                var serviceSupply = await _dbContext.ServiceSupplies.FindAsync(model.ServiceSupplyId);
                if (serviceSupply != null)
                {
                    doctorName = serviceSupply.Person.FullName;
                    doctorAvatar = serviceSupply.Person.RealAvatar;                    
                }

                var person = await _dbContext.Persons.FindAsync(model.PersonId);
                if (person != null)
                {
                    customerName = person.FullName;
                    customerAvatar = person.RealAvatar;                    
                }

                if (model.Sender == ConsultancyMessageSender.CUSTOMER)
                {
                    personName = customerName;
                    personAvatar = customerAvatar;
                    if (serviceSupply != null && serviceSupply.Person.FcmInstanceIds != null)
                    {
                        instanceIds = serviceSupply.Person.FcmInstanceIds.Select(x => x.InstanceId).ToList();
                    }
                }
                else
                {
                    personName = doctorName;
                    personAvatar = doctorAvatar;
                    if (person != null && person.FcmInstanceIds != null)
                    {
                        instanceIds = person.FcmInstanceIds.Select(x => x.InstanceId).ToList();
                    }
                }                

                foreach (var item in instanceIds)
                {
                    var payLoad = new ConsultancyMessageNotificationPayload
                    {
                        NotificationType = NotificationType.ConsultancyMessage,
                        ChatId = model.ConsultancyId,
                        ServiceSupplyId = model.ServiceSupplyId,
                        PersonId = model.PersonId,     
                        PersonName = personName,
                        PersonAvatar = personAvatar,
                        MessageId = result.Id,
                        Sender = model.Sender,
                        Content = result.Message,
                        Type = result.Type
                    };

                    await _notificationService.SendConsultancyMessageDeliveryNotificationAsync(item, personName, result.Message?.TruncateLongString(50), payLoad);
                }
            }
            catch
            {
            }
        }

        // Get chats for consultant
        public async Task<ConsultantChatsResultDTO> GetConsultantChatsPagingListAsync(string doctorUserMobile, ConsultantChatsFilterModel filterModel, Lang lang, int page = 0, int pageSize = 12)
        {
            var doctorPerson = await _dbContext.Persons.FirstOrDefaultAsync(x => x.Mobile == doctorUserMobile);

            if (doctorPerson == null) throw new AwroNoreException("Doctor person not found");

            var serviceSupplieIds = await _dbContext.ServiceSupplies.Where(x => x.PersonId == doctorPerson.Id && x.ConsultancyEnabled).Select(x => x.Id).ToListAsync();

            var query = _dbContext.Consultancies.Where(x => x.Status != ConsultancyStatus.REMOVED_BY_DOCTOR);

            query = query.Where(x => x.Status == filterModel.Status && serviceSupplieIds.Contains(x.ServiceSupplyId));

            query = query.Where(x => x.ConsultancyMessages.Any());

            var totalCount = await query.CountAsync();

            query = query.OrderByDescending(x => x.CreatedAt).Skip(pageSize * page).Take(pageSize);

            var chats = await query.Select(x => new ConsultantChatsDTO
            {
                Id = x.Id,
                PersonId = x.PersonId,
                ServiceSupplyId = x.ServiceSupplyId,
                FinishedAt = x.FinishedAt != null ? x.FinishedAt.ToString() : "",
                StartedAt = x.StartedAt != null ? x.StartedAt.ToString() : "",
                Status = x.Status,
                PersonName = lang == Lang.KU ? x.Person.FullName_Ku : lang == Lang.AR ? x.Person.FullName_Ar : x.Person.FullName,
                PersonAvatar = x.Person.RealAvatar,
                LastMessage = x.ConsultancyMessages.Any() ? x.ConsultancyMessages.OrderByDescending(m => m.CreatedAt).FirstOrDefault().Type == ConsultancyMessageType.PHOTO ? Global.Photo : x.ConsultancyMessages.OrderByDescending(m => m.CreatedAt).FirstOrDefault().Type == ConsultancyMessageType.VOICE ? Global.Voice : x.ConsultancyMessages.OrderByDescending(m => m.CreatedAt).FirstOrDefault().Content : "",
            }).ToListAsync();

            var result = new ConsultantChatsResultDTO
            {
                TotalCount = totalCount,
                Chats = chats
            };

            return result;
        }

        // Get chats for user customer
        public async Task<ConsultantChatsResultDTO> GetMyChatsPagingListAsync(string userMobile, MyChatsFilterModel filterModel, Lang lang, int page = 0, int pageSize = 12)
        {
            var person = await _dbContext.Persons.FirstOrDefaultAsync(x => x.Mobile == userMobile);

            if (person == null) throw new AwroNoreException("User Person not found");

            var query = _dbContext.Consultancies.Where(x => x.PersonId == person.Id);

            if (filterModel.Status != null)
            {
                if (filterModel.Status == ConsultancyStatus.FINISHED)
                {
                    query = query.Where(x => x.Status == filterModel.Status || x.Status == ConsultancyStatus.REMOVED_BY_DOCTOR);
                }
                else
                {
                    query = query.Where(x => x.Status == filterModel.Status);
                }
            }

            if (filterModel.ServiceSupplyId != null)
            {
                query = query.Where(x => x.ServiceSupplyId == filterModel.ServiceSupplyId);
            }

            var totalCount = await query.CountAsync();

            query = query.OrderByDescending(x => x.CreatedAt).Skip(pageSize * page).Take(pageSize);

            var chats = await query.Select(x => new ConsultantChatsDTO
            {
                Id = x.Id,
                PersonId = x.PersonId,
                ServiceSupplyId = x.ServiceSupplyId,
                FinishedAt = x.FinishedAt != null ? x.FinishedAt.ToString() : "",
                StartedAt = x.StartedAt != null ? x.StartedAt.ToString() : "",
                Status = x.Status != ConsultancyStatus.REMOVED_BY_DOCTOR ? x.Status : ConsultancyStatus.FINISHED,
                PersonName = lang == Lang.KU ? x.ServiceSupply.Person.FullName_Ku : lang == Lang.AR ? x.ServiceSupply.Person.FullName_Ar : x.ServiceSupply.Person.FullName,
                PersonAvatar = x.ServiceSupply.Person.RealAvatar,
                LastMessage = x.ConsultancyMessages.Any() ? x.ConsultancyMessages.OrderByDescending(m => m.CreatedAt).FirstOrDefault().Type == ConsultancyMessageType.PHOTO ? Global.Photo : x.ConsultancyMessages.OrderByDescending(m => m.CreatedAt).FirstOrDefault().Type == ConsultancyMessageType.VOICE ? Global.Voice : x.ConsultancyMessages.OrderByDescending(m => m.CreatedAt).FirstOrDefault().Content : "",
            }).ToListAsync();

            var result = new ConsultantChatsResultDTO
            {
                TotalCount = totalCount,
                Chats = chats
            };

            return result;
        }

        public async Task<DoctorConsultancyChatDTO> GetDoctorConsultancyMessagesAsync(string doctorUserMobile, int chatId, Lang lang)
        {
            var doctorPerson = await _dbContext.Persons.FirstOrDefaultAsync(x => x.Mobile == doctorUserMobile);

            if (doctorPerson == null) throw new AwroNoreException("Not any person found for this mobile number");

            var currentChat = await _dbContext.Consultancies.FindAsync(chatId);

            if (currentChat == null) throw new AwroNoreException("This chat is no longer available");

            if (!doctorPerson.ServiceSupplies.Any(x => x.Id == currentChat.ServiceSupplyId)) throw new AwroNoreException("You don't have permission to load this chat");

            var appSettings = _options.Value.AwroNoreSettings;

            var chatscreenMention = lang == Lang.KU ? appSettings.ConsultantChatScreenMention.MentionKu : lang == Lang.AR ? appSettings.ConsultantChatScreenMention.MentionAr : appSettings.ConsultantChatScreenMention.Mention;

            var contactStatus = lang == Lang.KU ? appSettings.ContactDefaultStatus.StatusKu : lang == Lang.AR ? appSettings.ContactDefaultStatus.StatusAr : appSettings.ContactDefaultStatus.Status;

            var form = await _dbContext.DiseaseRecordsForms.FirstOrDefaultAsync(x => x.PersonId == currentChat.PersonId);            

            var result = new DoctorConsultancyChatDTO
            {
                Id = currentChat.Id,
                Status = currentChat.Status,
                ServiceSupplyId = currentChat.ServiceSupplyId,
                PersonId = currentChat.PersonId,
                StartedAt = currentChat.StartedAt != null ? currentChat.StartedAt.ToString() : "",
                FinishedAt = currentChat.FinishedAt != null ? currentChat.FinishedAt.ToString() : "",
                ChatScreenMention = chatscreenMention,
                ContactStatus = contactStatus,
                Messages = currentChat.ConsultancyMessages.Select(x => new ConsultancyMessageDTO
                {
                    Id = x.Id,
                    SenderReceiverType = x.Sender == ConsultancyMessageSender.CONSULTANT ? MessageSenderReceiverType.SENT : MessageSenderReceiverType.RECEIVED,
                    ContactName = x.Sender == ConsultancyMessageSender.CONSULTANT ? (lang == Lang.KU ? x.ServiceSupply.Person.FullName_Ku : lang == Lang.AR ? x.ServiceSupply.Person.FullName_Ar : x.ServiceSupply.Person.FullName) : (lang == Lang.KU ? x.Person.FullName_Ku : lang == Lang.AR ? x.Person.FullName_Ar : x.Person.FullName),
                    ContactAvatar = x.Sender == ConsultancyMessageSender.CONSULTANT ? x.ServiceSupply.Person.RealAvatar : x.Person.RealAvatar,
                    Message = x.Content,
                    Time = x.CreatedAt.ToString("HH:mm"),
                    Type = x.Type
                }).ToList(),
                DiseaseRecordsForm = form == null ? null : new AN.Core.DTO.Profile.DiseaseRecordsFormDTO
                {
                    Age = form.Age,
                    DoYouSmoke = form.DoYouSmoke,
                    DrugsYouUsed = form.DrugsYouUsed,
                    HadSurgery = form.HadSurgery,
                    HasLongTermDisease = form.HasLongTermDisease,
                    LongTermDiseasesDescription = form.LongTermDiseasesDescription,
                    MedicalAllergies = form.MedicalAllergies,
                    PersonId = currentChat.PersonId,
                    SurgeriesDescription = form.SurgeriesDescription
                }
            };

            return result;
        }

        public async Task<ConsultantChatsDTO> SetConsultancyStatusAsync(string doctorUserMobile, int chatId, ConsultancyStatus status, Lang lang)
        {
            var doctorPerson = await _dbContext.Persons.FirstOrDefaultAsync(x => x.Mobile == doctorUserMobile);

            if (doctorPerson == null) throw new AwroNoreException("Not any person found for this mobile number");

            var chat = await _dbContext.Consultancies.FindAsync(chatId);

            if (chat == null) throw new AwroNoreException("This chat is no longer available");

            if (!doctorPerson.ServiceSupplies.Any(y => y.Id == chat.ServiceSupplyId)) throw new AwroNoreException("You don't have permission to load this chat");

            chat.Status = status;

            if (status == ConsultancyStatus.STARTED)
            {
                chat.StartedAt = DateTime.Now;
            }

            if (status == ConsultancyStatus.FINISHED)
            {
                chat.FinishedAt = DateTime.Now;
            }

            _dbContext.Entry(chat).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();

            return new ConsultantChatsDTO
            {
                Id = chat.Id,
                PersonId = chat.PersonId,
                ServiceSupplyId = chat.ServiceSupplyId,
                FinishedAt = chat.FinishedAt != null ? chat.FinishedAt.ToString() : "",
                StartedAt = chat.StartedAt != null ? chat.StartedAt.ToString() : "",
                Status = chat.Status,
                PersonName = lang == Lang.KU ? chat.Person.FullName_Ku : lang == Lang.AR ? chat.Person.FullName_Ar : chat.Person.FullName,
                PersonAvatar = chat.Person.RealAvatar,
                LastMessage = chat.ConsultancyMessages.Any() ? chat.ConsultancyMessages.OrderByDescending(m => m.CreatedAt).FirstOrDefault().Content : "",
            };
        }

        public async Task RemoveConsultancyAsync(int consultancyId, string doctorPersonMobile)
        {
            var doctorPerson = await _dbContext.Persons.FirstOrDefaultAsync(x => x.Mobile == doctorPersonMobile);

            if (doctorPerson == null) throw new AwroNoreException("Not any person found for this mobile number");

            var chat = await _dbContext.Consultancies.FindAsync(consultancyId);

            if (chat == null) throw new AwroNoreException("This chat is no longer available");

            if (!doctorPerson.ServiceSupplies.Any(y => y.Id == chat.ServiceSupplyId)) throw new AwroNoreException("You don't have permission to load this chat");

            if (chat.Status != ConsultancyStatus.FINISHED) throw new AwroNoreException("You can't remove unfinished chat");

            chat.Status = ConsultancyStatus.REMOVED_BY_DOCTOR;

            _dbContext.Entry(chat).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();
        }
    }
}

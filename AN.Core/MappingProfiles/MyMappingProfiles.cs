using AN.Core.Domain;
using AN.Core.DTO;
using AN.Core.Models;
using AN.Core.ViewModels;
using AutoMapper;
using System;

namespace AN.Core.MappingProfiles
{
    /// <summary>
    /// When the application starts, every classes that inherit from a Profile class 
    /// will be registered by AutoMapper and the mapping strategy will be enabled
    /// </summary>
    public class MyMappingProfiles : Profile
    {
        public MyMappingProfiles()
        {
            CreateMap<Person, PersonCreateUpdateViewModel>();
            CreateMap<PersonCreateUpdateViewModel, Person>();
            CreateMap<Drug, PrintPrescriptTreatmentsModel>();

            CreateMap<PatientHistoryInfoModel, PastMedicalHistory>();
            CreateMap<PastMedicalHistory, PatientHistoryInfoModel>();

            CreateMap<DrugDTO, Drug>();
            CreateMap<Drug, DrugDTO>();

            CreateMap<Notification, NotificationCreateUpdateViewModel>().ForMember(p => p.ValidUntil, opt => opt.MapFrom((notification, model, unused, ctx) =>
            {
                return notification.ValidUntil.ToString("yyyy/MM/dd");
            }));

            CreateMap<NotificationCreateUpdateViewModel, Notification>().ForMember(p => p.ValidUntil, opt => opt.MapFrom((model, notification, unused, ctx) =>
            {
                return DateTime.Parse(model.ValidUntil);
            }));

            CreateMap<CmsCategoryCreateUpdateViewModel, ContentCategory>().ForMember(p => p.CreatedAt, opt => opt.MapFrom((model, category, unused, ctx) =>
            {
                return DateTime.Now;
            }));
            CreateMap<ContentCategory, CmsCategoryCreateUpdateViewModel>();

            CreateMap<CmsArticleCreateUpdateViewModel, ContentArticle>().ForMember(p => p.CreatedAt, opt => opt.MapFrom((model, article, unused, ctx) =>
            {
                return DateTime.Now;
            })).ForMember(p => p.ImageUrl, opt => opt.MapFrom((model, article, unused, ctx) =>
            {
                return "";
            })).ForMember(p => p.ThumbnailUrl, opt => opt.MapFrom((model, article, unused, ctx) =>
            {
                return "";
            }));

            CreateMap<ContentArticle, CmsArticleCreateUpdateViewModel>();

            CreateMap<RegisterOfflineData, RegisterDownloadAppModel>();
            CreateMap<RegisterDownloadAppModel, RegisterOfflineData>();
        }
    }
}

using AN.BLL.Core.Appointments;
using AN.BLL.Core.Appointments.InProgress;
using AN.BLL.Core.Services;
using AN.BLL.Core.Services.Messaging.Notifications;
using AN.BLL.Core.Services.Messaging.SMS.Kurtename;
using AN.BLL.Core.Services.Messaging.SMS.Plivo;
using AN.BLL.DataRepository;
using AN.BLL.DataRepository.ActivityLog;
using AN.BLL.DataRepository.Appointments;
using AN.BLL.DataRepository.Clinics;
using AN.BLL.DataRepository.ContactUsRepo;
using AN.BLL.DataRepository.Drugs;
using AN.BLL.DataRepository.Expertises;
using AN.BLL.DataRepository.HealthServices;
using AN.BLL.DataRepository.Hospitals;
using AN.BLL.DataRepository.Insurances;
using AN.BLL.DataRepository.Patients;
using AN.BLL.DataRepository.Persons;
using AN.BLL.DataRepository.Places;
using AN.BLL.DataRepository.PolyclinicMessages;
using AN.BLL.DataRepository.Polyclinics;
using AN.BLL.DataRepository.Rating;
using AN.BLL.DataRepository.Resources;
using AN.BLL.DataRepository.Schedules;
using AN.BLL.DataRepository.Security;
using AN.BLL.DataRepository.ServiceSupplies;
using AN.BLL.DataRepository.StatisticsRepo;
using AN.BLL.DataRepository.TreatmentHistories;
using AN.BLL.Jobs.AppointmentRemider;
using AN.BLL.Services;
using AN.BLL.Services.Doctors;
using AN.BLL.Services.Filters;
using AN.BLL.Services.Http;
using AN.BLL.Services.IdentityServer;
using AN.BLL.Services.Location;
using AN.BLL.Services.MedicalRequest;
using AN.BLL.Services.Offers;
using AN.BLL.Services.Profile;
using AN.BLL.Services.Reports;
using AN.BLL.Services.Search;
using AN.BLL.Services.Treatment;
using AN.BLL.Services.Turns;
using AN.BLL.Services.Upload;
using AN.Core;
using AN.Core.Data;
using AN.DAL;
using AN.Web.App_Code;
using AN.Web.AppCode;
using AN.Web.Helper.TokenParser;
using AutoMapper;
using Hangfire;
using Hangfire.SqlServer;
using JqueryDataTables.ServerSide.AspNetCoreWeb.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using Shared.Constants.LabratoryNeeds;
using Shared.Constants.SonarNeeds;
using System;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using WebApiContrib.Core.Formatter.Bson;

namespace AN.Web
{
    public static class ConfigurationManager
    {
        public static IServiceCollection ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["ConnectionStrings:ConnectionString"];

            services.AddDbContext<BanobatDbContext>(options =>
            {
                options.UseLazyLoadingProxies(true);
                options.UseSqlServer(connectionString, option => { option.EnableRetryOnFailure(); option.UseNetTopologySuite(); });
            });

            services.AddTransient<BanobatDbContext>();

            return services;
        }

        public static IServiceCollection ConfigureInterfaces(this IServiceCollection services)
        {
            // Transient – Each time a transient object is requested, a new instance will be created
            // Scoped – The same object will be used when requested within the same request
            // Singleton – The same object will always be used across all requests

            // SINGLETONS
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.TryAddSingleton<IIpaPoolSingleton, IpaPoolSingleton>();

            // TRANSIENTS
            services.AddTransient(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddTransient<IOfferRepository, OfferRepository>();
            services.AddTransient<ITokenParser, TokenParser>();
            services.AddTransient<IWorkContext, WebWorkContext>();
            services.AddTransient<IPlaceService, PlaceService>();
            services.AddTransient<IResourcesService, ResourcesService>();
            services.AddTransient<IHospitalService, HospitalService>();
            services.AddTransient<IExpertiseService, ExpertiseService>();
            services.AddTransient<IServiceSupplyService, ServiceSupplyService>();
            services.AddTransient<IDoctorServiceManager, DoctorServiceManager>();
            services.AddTransient<IServiceSupplyManager, ServiceSupplyManager>();
            services.AddTransient<IClinicService, ClinicService>();
            services.AddTransient<IShiftCenterService, ShiftCenterService>();
            services.AddTransient<IAppointmentService, AppointmentService>();
            services.AddTransient<IStatisticsService, StatisticsService>();
            services.AddTransient<IIPAsManager, IPAsManager>();
            services.AddTransient<IPersonService, PersonService>();
            services.AddTransient<IContactUsService, ContactUsService>();
            services.AddTransient<ICommonUtils, CommonUtils>();
            services.AddTransient<IClinicPersonsService, ClinicPersonsService>();
            services.AddTransient<IServicesService, ServicesService>();
            services.AddTransient<IScheduleInsuranceService, ScheduleInsuranceService>();
            services.AddTransient<IInsuranceService, InsuranceService>();
            services.AddTransient<IUsualScheduleService, UsualScheduleService>();
            services.AddTransient<IPlivoService, PlivoService>();
            services.AddTransient<IScheduleManager, ScheduleManager>();
            services.AddTransient<IScheduleService, ScheduleService>();
            services.AddTransient<IActivityLogService, ActivityLogService>();
            services.AddTransient<IShiftCenterMessageService, ShiftCenterMessageService>();
            services.AddTransient<IBlockedMobileService, BlockedMobilesService>();
            services.AddTransient<IAppointmentsManager, AppointmentsManager>();
            services.AddTransient<INotificationService, NotificationService>();
            services.AddTransient<ITurnsService, TurnsService>();
            services.AddTransient<IRatingService, RatingService>();
            services.AddTransient<IFiltersService, FiltersService>();
            services.AddTransient<ILocationService, LocationService>();
            services.AddTransient<IProfileService, ProfileService>();
            services.AddTransient<IOffersService, OffersService>();
            services.AddTransient<IPatientService, PatientService>();
            services.AddTransient<ITreatmentHistoryService, TreatmentHistoryService>();
            services.AddTransient<IDrugsService, DrugsService>();
            services.AddTransient<ITreatmentService, TreatmentService>();
            services.AddTransient<IPharmacyRepository, PharmacyRepository>();
            services.AddTransient<IPharmacyPrescriptionRepository, PharmacyPrescriptionRepository>();
            services.AddTransient<IUploadService, UploadService>();
            services.AddTransient<IIdentityService, IdentityService>();
            services.AddTransient<IHttpService, HttpService>();
            services.AddTransient<IPharmacyDoneItemsRepository, PharmacyDoneItemsRepository>();
            services.AddTransient<IDoctorsService, DoctorsService>();
            services.AddTransient<IPrescriptionRepository, PrescriptionRepository>();
            services.AddTransient<IDashboardReportsService, DashboardReportsService>();
            services.AddTransient<ISonarNeedsProvider, SonarNeedsProvider>();
            services.AddTransient<ILabratoryNeedsProvider, LabratoryNeedsProvider>();
            services.AddTransient<IInvoiceRepository, InvoiceRepository>();
            services.AddTransient<INotificationRepository, NotificationRepository>();
            services.AddTransient<IContentCategoryRepository, ContentCategoryRepository>();
            services.AddTransient<IContentArticleRepository, ContentArticleRepository>();
            services.AddTransient<ICmsService, CmsService>();
            services.AddTransient<IConsultancyService, ConsultancyService>();
            services.AddTransient<IConsultancyRepository, ConsultancyRepository>();
            services.AddTransient<IHealthBankService, HealthBankService>();
            services.AddTransient<IInsuranceServiceService, InsuranceServiceService>();
            services.AddTransient<IAttachmentService, AttachmentService>();
            services.AddTransient<IKurtenameSmsService, KurtenameSmsService>();
            services.AddTransient<IMedicalRequestService, MedicalRequestService>();
            services.AddTransient<IAppointmentReminderJob, AppointmentReminderJob>();
            services.AddTransient<ISearchService, SearchService>();
            services.AddScoped<LogFilterAttribute>();
            return services;
        }

        public static IServiceCollection ConfigureMvc(this IServiceCollection services)
        {
            services.AddMemoryCache();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddSession(opts =>
            {
                opts.Cookie.IsEssential = true; // make the session cookie Essential
                opts.IdleTimeout = TimeSpan.FromMinutes(60);
            });

            services.AddMvc(options =>
            {
                // Replaced with ErrorHandlingMiddlewre \\
                //options.Filters.Add(typeof(AccountingGlobalExceptionFilter));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
            .AddBsonSerializerFormatters();

            services.AddJqueryDataTables();

            return services;
        }

        public static IServiceCollection ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";

            })
            .AddCookie("Cookies", options =>
            {
                options.AccessDeniedPath = new PathString("/Account/AccessDenied");
            })
            .AddOpenIdConnect("oidc", options =>
            {
                options.Authority = configuration["IdentityServer:Authority"];
                options.RequireHttpsMetadata = false;
                options.ClientId = "awronore_mvc";
                options.SaveTokens = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    RoleClaimType = "role"
                };

                options.Events.OnAuthorizationCodeReceived = async n =>
                {
                    await Task.FromResult(0);
                };

                options.Events.OnTokenValidated = async n =>
                {
                    //var cookieLoginAs = n.HttpContext.Request.Cookies["LoginAs"];
                    //if (string.IsNullOrEmpty(cookieLoginAs))
                    //{
                    //    cookieLoginAs = n.SecurityToken.Claims.FirstOrDefault(x => x.Type == "LoginAs")?.Value;

                    //    n.HttpContext.Response.Cookies.Append("LoginAs", cookieLoginAs);
                    //}
                    var loginAs = n.SecurityToken.Claims.FirstOrDefault(x => x.Type == "LoginAs")?.Value;
                    if (!string.IsNullOrEmpty(loginAs))
                    {
                        if (loginAs == "rootadmin") loginAs = "admin";

                        n.Properties.RedirectUri = $"/{loginAs}/home/";
                    }
                    await Task.FromResult(0);
                };

                options.Events.OnUserInformationReceived = async n =>
                {
                    await Task.FromResult(0);
                };

                options.Events.OnUserInformationReceived = async n =>
                {
                    await Task.FromResult(0);
                };

                //options.Events.OnRedirectToIdentityProvider = async n =>
                //{
                //    if(n.ProtocolMessage.RequestType == Microsoft.IdentityModel.Protocols.OpenIdConnect.OpenIdConnectRequestType.Authentication)
                //    {
                //        if (n.Request.Path.StartsWithSegments("/api") && n.Response.StatusCode == (int)HttpStatusCode.OK)
                //        {
                //            n.Response.Clear();
                //            n.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                //            n.HandleResponse();
                //        }
                //    }                    
                //    await Task.FromResult(0);
                //};
            }).AddJwtBearer(options =>
            {
                options.Authority = configuration["IdentityServer:Authority"];
                options.Audience = configuration["Jwt:Audience"]; // name of the API resource
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    RoleClaimType = "role"
                    //IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
                };
                //options.Events.OnAuthenticationFailed = async n =>
                //{
                //    await Task.FromResult(0);
                //};
            });

            return services;
        }

        public static IServiceCollection ConfigureLocalization(this IServiceCollection services)
        {
            var enCulture = new CultureInfo(SupportedLangs.EN);
            var arCulture = new CultureInfo(SupportedLangs.AR);
            var kuCulture = new CultureInfo(SupportedLangs.KU);

            var dateformat = new DateTimeFormatInfo
            {
                ShortDatePattern = "yyyy/MM/dd",
                LongDatePattern = "yyyy/MM/dd hh:mm:ss tt"
            };
            enCulture.DateTimeFormat = dateformat;
            arCulture.DateTimeFormat = enCulture.DateTimeFormat;
            kuCulture.DateTimeFormat = enCulture.DateTimeFormat;

            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                {
                    enCulture,
                    arCulture,
                    kuCulture
                };
                options.DefaultRequestCulture = new RequestCulture(culture: SupportedLangs.EN, uiCulture: SupportedLangs.EN);
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
                options.RequestCultureProviders.Insert(0, new CustomRequestCultureProvider(context =>
                {
                    if (context.Request.Path.StartsWithSegments("/api"))
                    {
                        var userLangs = context.Request.Headers["Accept-Language"].ToString();
                        var firstLang = userLangs.Split(',').FirstOrDefault();
                        var defaultLang = string.IsNullOrEmpty(firstLang) ? SupportedLangs.EN : firstLang;
                        return Task.FromResult(new ProviderCultureResult(defaultLang, defaultLang));
                    }
                    else
                    {
                        var cookieCulture =  context.Request.Cookies["_culture"];

                        var currentCulture = string.IsNullOrEmpty(cookieCulture) ? SupportedLangs.EN : cookieCulture;

                        return Task.FromResult(new ProviderCultureResult(currentCulture, currentCulture));
                    }

                }));
            });
            return services;
        }

        public static IServiceCollection ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.Load("AN.Core"));

            return services;
        }

        public static IServiceCollection ConfigureHttpClient(this IServiceCollection services, IConfiguration Configuration)
        {
            //set 5 min as the lifetime for each HttpMessageHandler int the pool
            services.AddHttpClient("extendedhandlerlifetime").SetHandlerLifetime(TimeSpan.FromMinutes(5));

            services.AddHttpClient<IIdentityService, IdentityService>();               

            return services;
        }

        /// <summary>
        /// Enabling Cross-Origin Requests (CORS)
        /// this basically makes our API accept requests from any origin
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection ConfigureCORS(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                // TODO => Set CORS Later After Development
                //options.AddPolicy("CorsPolicy",
                //    builder => builder
                //      .WithOrigins("https://awronore.krd",
                //                   "https://www.awronore.krd",
                //                   "http://awronore.krd",
                //                   "http://www.awronore.krd",
                //                   "http://192.168.100.33:5000",
                //                   "http://localhost:5000")
                //      .AllowAnyMethod()
                //      .AllowAnyHeader()
                //      .AllowCredentials()
                //.Build());

                options.AddPolicy("CorsPolicy",
                    builder => builder
                      .AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader()
                      .AllowCredentials()
                .Build());
            });

            return services;
        }

        public static IServiceCollection ConfigureHangfire(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["ConnectionStrings:HangfireConnectionString"];

            // Add Hangfire services.
            services.AddHangfire(config => config
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage(connectionString, new SqlServerStorageOptions
                {
                    CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                    SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                    QueuePollInterval = TimeSpan.Zero,
                    UseRecommendedIsolationLevel = true,
                    UsePageLocksOnDequeue = true,
                    DisableGlobalLocks = true
                }));

            return services;
        }
    }
}

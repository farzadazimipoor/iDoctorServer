using AN.BLL.DataRepository.Places;
using AN.BLL.DataRepository.ServiceSupplies;
using AN.Core;
using AN.Core.Data;
using AN.DAL;
using AN.WebAPI.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AN.WebAPI
{
    public static class ConfigurationManager
    {
        public static IServiceCollection ConfigurePolicy(this IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            return services;
        }

        public static IServiceCollection ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["ConnectionStrings:ConnectionString"];

            services.AddDbContext<BanobatDbContext>(options =>
            {
                options.UseLazyLoadingProxies().UseSqlServer(connectionString, option => { option.EnableRetryOnFailure(); });
            });

            services.AddTransient<BanobatDbContext>();

            return services;
        }       

        public static IServiceCollection ConfigureInterfaces(this IServiceCollection services)
        {
            services.AddTransient(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddTransient<IWorkContext, ApiWorkContext>();
            services.AddTransient<IPlaceService, PlaceService>();
            services.AddTransient<IServiceSupplyService, ServiceSupplyService>();
            return services;
        }

        public static IServiceCollection ConfigureMvc(this IServiceCollection services)
        {
            services.AddMemoryCache();

            //services.AddMvc(options =>
            //{
            //    options.Filters.Add(typeof(IBazarGlobalExceptionFilter));

            //}).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>()
                    .AddScoped(x => x.GetRequiredService<IUrlHelperFactory>()
                    .GetUrlHelper(x.GetRequiredService<IActionContextAccessor>().ActionContext));

            return services;
        }

        public static IServiceCollection ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)             
            .AddJwtBearer(options =>
            {
                options.Authority = configuration["IdentityServer:Authority"];
                // name of the API resource
                options.Audience = configuration["Jwt:Audience"];
                options.RequireHttpsMetadata = false;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    //IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
                };
            });

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

        public static IServiceCollection ConfigureLocalization(this IServiceCollection services)
        {
            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                {
                    new CultureInfo(SupportedLangs.EN),
                    new CultureInfo(SupportedLangs.AR),
                    new CultureInfo(SupportedLangs.KU)
                };
                options.DefaultRequestCulture = new RequestCulture(culture: SupportedLangs.EN, uiCulture: SupportedLangs.EN);
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
                options.RequestCultureProviders.Insert(0, new CustomRequestCultureProvider(context =>
                {
                    var userLangs = context.Request.Headers["Accept-Language"].ToString();
                    var firstLang = userLangs.Split(',').FirstOrDefault();
                    var defaultLang = string.IsNullOrEmpty(firstLang) ? SupportedLangs.EN : firstLang;
                    return Task.FromResult(new ProviderCultureResult(defaultLang, defaultLang));
                }));
            });
            return services;
        }
    }
}

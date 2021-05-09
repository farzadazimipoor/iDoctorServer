using Identity.BLL.DataRepository.UserRepository;
using Identity.BLL.Services.Email;
using Identity.BLL.Services.Kurtename;
using Identity.BLL.Services.Plivo;
using Identity.Core.Domain;
using Identity.Core.Models;
using Identity.DAL;
using Identity.Web.Infrastructure.Middleware;
using Identity.Web.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace Identity.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }
        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // DB-CONTEXT
            services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // ASP.NET IDENTITY
            services.AddIdentity<ApplicationUser, ApplicationRole>().AddEntityFrameworkStores<AppIdentityDbContext>().AddDefaultTokenProviders();

            // CORS
            services.AddCors(options =>
            {
                // TODO => Set CORS Later After Development
                options.AddPolicy("CorsPolicy", corsBuilder => corsBuilder
                       .AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .AllowCredentials()
                 .Build());
            });

            // MVC & SESSION
            services.AddSession(opts =>
            {
                opts.Cookie.IsEssential = true; // make the session cookie Essential
                opts.IdleTimeout = TimeSpan.FromMinutes(60);
            });
            services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_1);

            // IIS
            services.Configure<IISOptions>(iis =>
            {
                iis.AuthenticationDisplayName = "Windows";
                iis.AutomaticAuthentication = false;
            });

            // IDENTITY-OPTIONS
            services.Configure<IdentityOptions>(options =>
            {
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
            });

            // IDENTITY-SERVER-4
            var builder = services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;
            }).AddInMemoryIdentityResources(Config.GetIdentityResources())
              .AddInMemoryApiResources(Config.GetApis())
              .AddInMemoryClients(Config.GetClients())
              .AddAspNetIdentity<ApplicationUser>()
              .AddExtensionGrantValidator<AuthenticationGrant>()
              .AddProfileService<IdentityUserProfileService>();

            if (Environment.IsDevelopment())
            {
                builder.AddDeveloperSigningCredential();
            }
            else
            {
                X509Certificate2 cert = null;
                using (X509Store certStore = new X509Store(StoreName.My, StoreLocation.LocalMachine))
                {
                    certStore.Open(OpenFlags.ReadOnly);
                    X509Certificate2Collection certCollection = certStore.Certificates.Find(
                        X509FindType.FindByThumbprint,
                        // This is our cert's file thumbprint. by double click and go to details tab we can find it
                        "b8664f51984f75f1b013027baaafe262ba21c0c4".ToUpper(),
                        false);
                    // Get the first cert with the thumbprint
                    if (certCollection.Count > 0)
                    {
                        cert = certCollection[0];
                        //Log.Logger.Information($"Successfully loaded cert from registry: {cert.Thumbprint}");
                    }
                }

                // Fallback to local file for development
                if (cert == null)
                {
                    cert = new X509Certificate2(Path.Combine(Environment.ContentRootPath, "Certificates\\awronoreids4.pfx"), "Ap@123456");
                    //Log.Logger.Information($"Falling back to cert from file. Successfully loaded: {cert.Thumbprint}");
                }
                builder.AddSigningCredential(cert);

                // ####################################################
                //      Configure Key Materials
                // ####################################################

                //throw new Exception("need to configure key material");
            }

            //services.AddAuthentication()
            //    .AddGoogle(options =>
            //    {
            //        // register your IdentityServer with Google at https://console.developers.google.com
            //        // enable the Google+ API
            //        // set the redirect URI to http://localhost:5000/signin-google
            //        options.ClientId = "copy client ID from Google here";
            //        options.ClientSecret = "copy client secret from Google here";
            //    });

            // SERVICES
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IPlivoSmsService, PlivoSmsService>();
            services.AddTransient<IEmailSenderService, EmailSenderService>();
            services.AddTransient<IKurtenameSmsService, KurtenameSmsService>();

            // Add functionality to inject IOptions<T>
            services.AddOptions();

            // Add our Config object so it can be injected
            services.Configure<AppSettings>(Configuration);
        }

        public void Configure(IApplicationBuilder app)
        {
            SeedData.EnsureSeedData(app);

            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseSession();

            app.UseCors("CorsPolicy");
            app.UseStaticFiles();
            app.UseIdentityServer();

            app.UseMiddleware(typeof(ErrorHandlingMiddleware));

            app.UseMvcWithDefaultRoute();
        }
    }
}

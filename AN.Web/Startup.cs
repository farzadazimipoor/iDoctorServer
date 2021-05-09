using AN.DAL;
using AN.Web.Infrastructure;
using AN.Web.Infrastructure.Middleware;
using Hangfire;
using Hangfire.Dashboard;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Shared.Settings;
using System;

namespace AN.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        private readonly ILogger<Startup> _logger;
        public Startup(IHostingEnvironment env, ILogger<Startup> logger)
        {
            _logger = logger;

            var builder = new ConfigurationBuilder().SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile("config.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // StimulSoft has problem with this capability
            // services.AddResponseCaching();

            services.ConfigureCORS()
                    .ConfigureMvc()
                    .ConfigureAuthentication(Configuration)
                    .ConfigureDbContext(Configuration)
                    .ConfigureInterfaces()
                    .ConfigureLocalization()
                    .ConfigureAutoMapper()
                    .ConfigureHttpClient(Configuration)
                    .ConfigureHangfire(Configuration);

            // Add functionality to inject IOptions<T>
            services.AddOptions();

            // Add our Config object so it can be injected
            services.Configure<AppSettings>(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            try
            {
                using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    serviceScope.ServiceProvider.GetService<BanobatDbContext>().Database.Migrate();

                    serviceScope.ServiceProvider.GetService<BanobatDbContext>().Database.EnsureCreated();

                    _logger.LogInformation("Migrations Updated Successfully");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to migrate or seed database");
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors("CorsPolicy");

            // app.UseStatusCodePagesWithRedirects("/Home/StatusCode?code={0}"); // TODO: Disbaled temporarily because of return error messages for app

            app.UseSession();

            app.UseRequestLocalization();

            app.UseAuthentication();

            // StimulSoft has problem with this capability
            // app.UseResponseCaching();

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseCookiePolicy();

            app.UseHangfireServer();

            app.UseHangfireDashboard("/jobs", new DashboardOptions
            {
                Authorization = new[] { new MyHangFireAuthorizationFilter() },
                IsReadOnlyFunc = (DashboardContext context) => true
            });

            app.UseMiddleware(typeof(ErrorHandlingMiddleware));

            app.UseAppointmentReminderJob();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                         name: "area",
                         template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

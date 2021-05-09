using AN.WebAPI.Infrastructure.Middleware;
using AN.Core.Models;
using AN.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace AN.WebAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        private readonly ILogger<Startup> _logger;
        public Startup(IHostingEnvironment env, ILogger<Startup> logger)
        {
            _logger = logger;

            var builder = new ConfigurationBuilder().SetBasePath(env.ContentRootPath).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureLocalization()
                    .ConfigurePolicy()
                    .ConfigureCORS()
                    .ConfigureMvc()
                    .ConfigureAuthentication(Configuration)
                    .ConfigureDbContext(Configuration)                    
                    .ConfigureInterfaces();

            // Add functionality to inject IOptions<T>
            services.AddOptions();

            // Add our Config object so it can be injected
            // services.Configure<AwroNoreAPISettings>(Configuration.GetSection("AwroNoreSettings"));

            //AutoMapperConfig.Configure("iB.BLL");
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
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseRequestLocalization();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseCors("CorsPolicy");

            app.UseMiddleware(typeof(ErrorHandlingMiddleware));

            app.UseMvc();           
        }
    }
}

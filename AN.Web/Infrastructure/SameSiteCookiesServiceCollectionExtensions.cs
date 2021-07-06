using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace AN.Web.Infrastructure
{
    public static class SameSiteCookiesServiceCollectionExtensions
    {
        private const SameSiteMode Unspecified = (SameSiteMode)(-1);

        public static IServiceCollection ConfigureNonBreakingSameSiteCookies(this IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.MinimumSameSitePolicy = Unspecified;
                options.OnAppendCookie = cookieContext =>
                   CheckSameSite(cookieContext.Context, cookieContext.CookieOptions);
                options.OnDeleteCookie = cookieContext =>
                   CheckSameSite(cookieContext.Context, cookieContext.CookieOptions);
            });

            return services;
        }

        private static void CheckSameSite(HttpContext httpContext, CookieOptions options)
        {
            if (options.SameSite == SameSiteMode.None)
            {
                var userAgent = httpContext.Request.Headers["User-Agent"].ToString();

                if (DisallowsSameSiteNone(userAgent))
                {
                    options.SameSite = Unspecified;
                }
            }
        }

        private static bool DisallowsSameSiteNone(string userAgent)
        {
            if (string.IsNullOrEmpty(userAgent))
            {
                return false;
            }

            if (userAgent.Contains("CPU iPhone OS 12")
               || userAgent.Contains("iPad; CPU OS 12"))
            {
                return true;
            }

            if (userAgent.Contains("Safari")
               && userAgent.Contains("Macintosh; Intel Mac OS X 10_14")
               && userAgent.Contains("Version/"))
            {
                return true;
            }

            // Cover Chrome 50-69, because some versions are broken by SameSite=None
            // and none in this range require it.
            // Note: this covers some pre-Chromium Edge versions,
            // but pre-Chromium Edge does not require SameSite=None.
            // Notes from Thinktecture:
            // We can not validate this assumption, but we trust Microsofts
            // evaluation. And overall not sending a SameSite value equals to the same
            // behavior as SameSite=None for these old versions anyways.
            if (userAgent.Contains("Chrome/5") ||
                userAgent.Contains("Chrome/6") ||
                userAgent.Contains("Chrome/8") ||
                userAgent.Contains("Chrome/9"))
            {
                return true;
            }

            return false;
        }
    }
}

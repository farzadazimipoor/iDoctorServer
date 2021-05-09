using Identity.BLL.DataRepository.UserRepository;
using Identity.Core.Exceptions;
using Identity.Core.Models;
using Identity.Web.Authorities;
using Identity.Web.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Identity.Web.Controllers
{
    public class AuthorityModel
    {
        public JObject payload { get; set; }
        public string token { get; set; }
    }

    [Produces("application/json")]
    [Route("api/identity/[controller]")]
    [ApiController]
    public class AuthorityController : ControllerBase
    {
        private Dictionary<string, AuthorityIssuer> _issuers;
        private readonly IOptions<AppSettings> _settings;
        public AuthorityController(IUserRepository userRepository, IOptions<AppSettings> settings)
        {
            _settings = settings;

            _issuers = new Dictionary<string, AuthorityIssuer>()
            {
                {
                    "owner",
                    AuthorityIssuer.Create(new AuthenticationAuthority(), "identity")
                        .Register("mobile", new MobileAuthority(userRepository))
                        .Register("otp", new OTPAuthority(userRepository))
                }
            };
        }
        [HttpPost("account")]
        public async Task<IActionResult> Account([FromBody] AuthorityModel model)
        {
            return await Account("", model);
        }

        [HttpPost("account/{authority}")]
        public async Task<IActionResult> Account(string authority, [FromBody] AuthorityModel model)
        {
            if (model == null || model?.payload == null) return Unauthorized();
           
            var authorities = _issuers["owner"].Authorities;

            if (!authorities.Any()) return Unauthorized();

            string token = model.token;
            if (string.IsNullOrWhiteSpace(authority))
            {
                authority = authorities.Keys.ToArray()[0];
                token = JwtHelper.GenerateToken(new Claim[] { }, _settings.Value.AwronoreSettings.OtpTimeOut);
            }

            if (string.IsNullOrWhiteSpace(token)) return Unauthorized();

            var principle = JwtHelper.GetClaimsPrincipal(token);

            if (principle?.Identity?.IsAuthenticated == true)
            {
                try
                {
                    var claimsIdentity = principle.Identity as ClaimsIdentity;
                    var (verifyResult, otp) = await _issuers["owner"].VerifyAsync(authority, claimsIdentity.Claims.ToArray(), model.payload);
                    if (verifyResult.Authority == null) return Ok(new { auth_token = verifyResult.Token });
                    return Ok(new
                    {
                        verify_token = verifyResult.Token,
                        authority = verifyResult.Authority,
                        parameters = verifyResult.Payload,
                        otp = "",
                        timeOut = _settings.Value.AwronoreSettings.OtpTimeOut
                    });
                }
                catch (Exception e)
                {
                    if (e is AwronoreIdentityException) throw e;

                    return Unauthorized();
                }
            }
            return Unauthorized();
        }
    }
}

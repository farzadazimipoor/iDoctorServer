using AN.Core.Models;
using IdentityModel;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace AN.Web.Helper.TokenParser
{
    public class TokenParser : ITokenParser
    {       
        public IdentityApplicationUser ParseToken(string accessToken)
        {
            if (!string.IsNullOrWhiteSpace(accessToken))
            {
                var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

                var jwtSecurityToken = jwtSecurityTokenHandler.ReadJwtToken(accessToken);

                var claims = jwtSecurityToken.Claims;

                var appUser = new IdentityApplicationUser
                {
                    Id = claims.FirstOrDefault(x => x.Type == JwtClaimTypes.Subject)?.Value ?? "",
                    UserName = claims.FirstOrDefault(x => x.Type == JwtClaimTypes.PreferredUserName)?.Value ?? "",
                    Email = claims.FirstOrDefault(x => x.Type == JwtClaimTypes.Email)?.Value ?? "",
                    EmailConfirmed = Convert.ToBoolean(claims.FirstOrDefault(x => x.Type == JwtClaimTypes.EmailVerified)?.Value ?? "false"),
                    PhoneNumber = claims.FirstOrDefault(x => x.Type == JwtClaimTypes.PhoneNumber)?.Value ?? "",
                    PhoneNumberConfirmed = Convert.ToBoolean(claims.FirstOrDefault(x => x.Type == JwtClaimTypes.PhoneNumberVerified)?.Value ?? "false"),
                    LoginAs = claims.FirstOrDefault(x => x.Type == "LoginAs")?.Value ?? "",                    
                };
                var roles = claims.Where(s => s.Type == JwtClaimTypes.Role).Select(s => s.Value).ToList();

                appUser.Roles.AddRange(roles);

                return appUser;
            }
            else
            {
                return new IdentityApplicationUser();
            }
        }
    }
}

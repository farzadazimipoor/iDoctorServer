using IdentityServer4.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Identity.Web.Helpers
{
    public class JwtHelper
    {
        private static readonly string Secret = "jwtsecret".Sha256();

        public static string GenerateToken(Claim[] claims, int timeout)
        {
            var symmetricKey = Convert.FromBase64String(Secret);

            var tokenHandler = new JwtSecurityTokenHandler();

            var now = DateTime.UtcNow;

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = now.AddSeconds(timeout),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var stoken = tokenHandler.CreateToken(tokenDescriptor);

            var token = tokenHandler.WriteToken(stoken);

            return token;
        }

        public static ClaimsPrincipal GetClaimsPrincipal(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            if (!(tokenHandler.ReadToken(token) is JwtSecurityToken)) return null;

            var symmetricKey = Convert.FromBase64String(Secret);

            var validationParameters = new TokenValidationParameters()
            {
                ClockSkew = TimeSpan.Zero,
                RequireExpirationTime = true,
                ValidateIssuer = false,
                ValidateAudience = false,
                IssuerSigningKey = new SymmetricSecurityKey(symmetricKey)
            };

            try
            {
                return tokenHandler.ValidateToken(token, validationParameters, out SecurityToken securityToken);
            }
            catch
            {
                return null;
            }
        }
    }
}

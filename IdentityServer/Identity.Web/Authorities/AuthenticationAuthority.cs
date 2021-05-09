using IdentityServer4.Models;
using System;
using System.Security.Claims;

namespace Identity.Web.Authorities
{
    public class AuthenticationAuthority : IAuthenticator
    {
        private static string authSecret = "authenticationsecretkey".Sha256();

        public Claim[] GetAuthenticationClaims(string identifier)
        {
            if (!Guid.TryParse(identifier, out Guid guid)) throw new FormatException();

            var hash = $"{identifier}:{authSecret}".Sha256();

            return new Claim[]
            {
                new Claim("auth_key", identifier),
                new Claim("auth_hash", hash)
            };
        }
    }
}

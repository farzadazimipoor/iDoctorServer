using Newtonsoft.Json.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Identity.Web.Authorities
{
    public interface IAuthority
    {
        string[] Payload { get; }

        Claim[] OnVerify(Claim[] claims, JObject payload, string identifier, out bool valid);

        Task<(Claim[], string otp)> OnForwardAsync(Claim[] claims);
    }


    public interface IAuthenticator
    {
        Claim[] GetAuthenticationClaims(string identifier);
    }
}

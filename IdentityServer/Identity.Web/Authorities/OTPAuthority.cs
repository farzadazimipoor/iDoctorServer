using Identity.BLL.DataRepository.UserRepository;
using IdentityServer4.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Identity.Web.Authorities
{
    public class OTPAuthority : IAuthority
    {
        private readonly IUserRepository _userRepository;       
        public OTPAuthority(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public string[] Payload => new string[] { "otp" };

        private async Task<(Claim[], string token)> GenerateOTPClaimsAsync(string phone)
        {
            var otp = await _userRepository.GenerateAndSendOTPAsync(phone);

            var sid = DateTime.Now.Ticks.ToString();

            var hash = string.Format("{0}:{1}", sid, otp).Sha256();

            return (new Claim[]
            {
                new Claim("otp_id", sid),
                new Claim("otp_hash", hash)
            }, otp);
        }

        public async Task<(Claim[], string otp)> OnForwardAsync(Claim[] claims)
        {
            var phone = claims.Single(c => c.Type == "phone").Value;

            var otpClaims = await GenerateOTPClaimsAsync(phone);

            return otpClaims;
        }

        public Claim[] OnVerify(Claim[] claims, JObject payload, string identifier, out bool valid)
        {
            valid = false;
            var id = claims.Single(c => c.Type == identifier).Value;
            var otpId = claims.Single(c => c.Type == "otp_id").Value;
            var hash = claims.Single(c => c.Type == "otp_hash").Value;
            if (string.Format("{0}:{1}", otpId, payload["otp"].ToString()).Sha256() == hash)
            {
                valid = true;
                return new Claim[]
                {
                new Claim(identifier, id)
                };
            }
            throw new ArgumentException();
        }
    }
}

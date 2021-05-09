using Identity.BLL.DataRepository.UserRepository;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Identity.Web.Authorities
{
    public class MobileAuthority : IAuthority
    {
        private IUserRepository _repository;
        public MobileAuthority(IUserRepository repository)
        {
            _repository = repository;
        }

        public string[] Payload => new string[] { "mobile" };

        public async Task<(Claim[], string otp)> OnForwardAsync(Claim[] claims)
        {
            throw new NotImplementedException();
        }

        public Claim[] OnVerify(Claim[] claims, JObject payload, string identifier, out bool valid)
        {
            valid = false;

            var user = _repository.GetUserAccount(payload["mobile"].ToString());

            if (user == null) throw new KeyNotFoundException();

            valid = true;

            return new Claim[]
            {
                new Claim(identifier, user.Id),
                new Claim("phone", user.PhoneNumber)
            };
        }
    }
}

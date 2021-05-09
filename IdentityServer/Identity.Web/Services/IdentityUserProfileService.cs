using Identity.BLL.DataRepository.UserRepository;
using IdentityModel;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Identity.Web.Services
{
    public class IdentityUserProfileService : IProfileService
    {
        private readonly IUserRepository _userRepository;

        public IdentityUserProfileService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var subjectId = context.Subject.GetSubjectId() ?? throw new ArgumentNullException("subjectId");

            var user = await _userRepository.FindBySubjectIdAsync(subjectId);

            if(user == null) context.IssuedClaims = new List<Claim>();

            var claims = new List<Claim>
            {               
                new Claim(JwtClaimTypes.Subject, user.Id),
                new Claim(JwtClaimTypes.PreferredUserName, user.UserName),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)                                          
            };

            if(user.UserProfile != null)
            {
                claims.Add(new Claim("LoginAs", user.UserProfile?.LoginAs.ToString().ToLower()));
                claims.Add(new Claim("CenterId", user.UserProfile?.CenterId != null ? user.UserProfile?.CenterId.ToString() : ""));
                claims.Add(new Claim("PersonId", user.UserProfile?.PersonId != null ? user.UserProfile?.PersonId.ToString() : ""));
                if(user.UserProfile?.ServiceSupplyIds != null)
                {
                    foreach (var serviceSupply in user.UserProfile?.ServiceSupplyIds)
                    {
                        claims.Add(new Claim("ServiceSupplyIds", serviceSupply.ToString()));
                    }
                }                       
            }

            var roles = await _userRepository.GetRolesAsync(user);
            foreach(var role in roles)
            {
                claims.Add(new Claim(JwtClaimTypes.Role, role));                        
            }            

            context.IssuedClaims.AddRange(claims);
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = false;

            var subjectId = context.Subject.GetSubjectId() ?? throw new ArgumentNullException("subjectId");

            var user = await _userRepository.FindBySubjectIdAsync(subjectId);

            if (user != null)
            {
                context.IsActive = !user.LockoutEnabled || !user.LockoutEnd.HasValue || user.LockoutEnd <= DateTime.Now;
            }
        }
    }
}

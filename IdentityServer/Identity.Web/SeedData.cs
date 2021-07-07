using Identity.Core.Domain;
using Identity.DAL;
using IdentityModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shared.Constants;
using System;
using System.Linq;
using System.Security.Claims;

namespace Identity.Web
{
    public class SeedData
    {
        public static void EnsureSeedData(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetService<AppIdentityDbContext>();
                context.Database.Migrate();
                context.Database.EnsureCreated();

                var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var roleMgr = scope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

                #region RootAdmin Role
                var rootadminRole = roleMgr.FindByNameAsync(SystemRoles.ROOTADMIN).Result;
                if (rootadminRole == null)
                {
                    var result = roleMgr.CreateAsync(new ApplicationRole
                    {
                        Name = SystemRoles.ROOTADMIN,
                        NormalizedName = SystemRoles.ROOTADMIN.ToUpper(),
                        IsSystemRole = true
                    }).Result;

                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }

                    Console.WriteLine($"{SystemRoles.ROOTADMIN} role created");
                }
                else
                {
                    Console.WriteLine($"{SystemRoles.ROOTADMIN} role already exists");
                }
                #endregion

                #region RootAdmin User
                var rootadminUser = userMgr.FindByNameAsync("rootadmin").Result;
                if (rootadminUser == null)
                {
                    rootadminUser = new ApplicationUser
                    {
                        UserName = "rootadmin",
                        PhoneNumberConfirmed = true,
                        PhoneNumber = "7505248743",
                        Email = "rootadmin@awronore.krd",
                        EmailConfirmed = true,
                        LockoutEnabled = false,
                        IsSystemUser = true,
                        UserProfile = new UserProfile
                        {
                            LoginAs = Shared.Enums.LoginAs.ROOTADMIN,
                            CenterId = null,
                            PersonId = null,
                            CreatedAt = DateTime.Now,
                            IsDeleted = false                           
                        }
                    };
                    var result = userMgr.CreateAsync(rootadminUser, "Ap@123456").Result;
                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }

                    result = userMgr.AddClaimsAsync(rootadminUser, new Claim[]{
                        new Claim(JwtClaimTypes.Name, "Root User"),
                        new Claim(JwtClaimTypes.GivenName, "Root"),
                        new Claim(JwtClaimTypes.FamilyName, "User"),
                        new Claim(JwtClaimTypes.Email, rootadminUser.Email),
                        new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                        new Claim(JwtClaimTypes.WebSite, "https://awronore.krd"),
                        new Claim(JwtClaimTypes.Address, @"{ 'street_address': '100 Metr Road', 'locality': 'Kurd', 'postal_code': 123, 'country': 'Kurdistan' }", IdentityServer4.IdentityServerConstants.ClaimValueTypes.Json),
                        new Claim("location", "Erbil")
                    }).Result;
                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }

                    result = userMgr.AddToRoleAsync(rootadminUser, SystemRoles.ROOTADMIN).Result;
                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }
                    Console.WriteLine("rootadmin user created");
                }
                else
                {
                    Console.WriteLine("rootadmin user already exists");
                }
                #endregion

                #region Admin Role
                var adminRole = roleMgr.FindByNameAsync(SystemRoles.ADMIN).Result;
                if (adminRole == null)
                {
                    var result = roleMgr.CreateAsync(new ApplicationRole
                    {
                        Name = SystemRoles.ADMIN,
                        NormalizedName = SystemRoles.ADMIN.ToUpper(),
                        IsSystemRole = true
                    }).Result;

                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }

                    Console.WriteLine("admin role created");
                }
                else
                {
                    Console.WriteLine("admin role already exists");
                }
                #endregion

                #region Admin User
                var adminUser = userMgr.FindByNameAsync("admin").Result;
                if (adminUser == null)
                {
                    adminUser = new ApplicationUser
                    {
                        UserName = "admin",
                        PhoneNumberConfirmed = true,
                        PhoneNumber = "7505248743",
                        Email = "admin@awronore.krd",
                        EmailConfirmed = true,
                        LockoutEnabled = false,
                        IsSystemUser = true,                        
                        UserProfile = new UserProfile
                        {
                            LoginAs = Shared.Enums.LoginAs.ADMIN,
                            CenterId = null,
                            PersonId = null,
                            CreatedAt = DateTime.Now,
                            IsDeleted = false
                        }
                    };
                    var result = userMgr.CreateAsync(adminUser, "Ap@123456").Result;
                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }

                    result = userMgr.AddClaimsAsync(adminUser, new Claim[]{
                        new Claim(JwtClaimTypes.Name, "Awronore Admin"),
                        new Claim(JwtClaimTypes.GivenName, "Admin"),
                        new Claim(JwtClaimTypes.FamilyName, ""),
                        new Claim(JwtClaimTypes.Email, adminUser.Email),
                        new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                        new Claim(JwtClaimTypes.WebSite, "https://awronore.krd"),
                        new Claim(JwtClaimTypes.Address, @"{ 'street_address': '100 Metr Road', 'locality': 'Kurd', 'postal_code': 123, 'country': 'Kurdistan' }", IdentityServer4.IdentityServerConstants.ClaimValueTypes.Json),
                        new Claim("location", "Erbil")
                    }).Result;
                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }

                    result = userMgr.AddToRoleAsync(adminUser, SystemRoles.ADMIN).Result;
                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }                   
                    Console.WriteLine("admin user created");
                }
                else
                {
                    Console.WriteLine("admin user already exists");
                }
                #endregion

                #region HospitalManager Role
                var hospitalManagerRole = roleMgr.FindByNameAsync(SystemRoles.HOSPITALMANAGER).Result;
                if (hospitalManagerRole == null)
                {
                    var result = roleMgr.CreateAsync(new ApplicationRole
                    {
                        Name = SystemRoles.HOSPITALMANAGER,
                        NormalizedName = SystemRoles.HOSPITALMANAGER.ToUpper(),
                        IsSystemRole = true
                    }).Result;

                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }

                    Console.WriteLine("hospitalmanager role created");
                }
                else
                {
                    Console.WriteLine("hospitalmanager role already exists");
                }
                #endregion

                #region Clinic Manager Role
                var clinicManagerRole = roleMgr.FindByNameAsync(SystemRoles.CLINICMANAGER).Result;
                if (clinicManagerRole == null)
                {
                    var result = roleMgr.CreateAsync(new ApplicationRole
                    {
                        Name = SystemRoles.CLINICMANAGER,
                        NormalizedName = SystemRoles.CLINICMANAGER.ToUpper(),
                        IsSystemRole = true
                    }).Result;

                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }

                    Console.WriteLine("clinicmanager role created");
                }
                else
                {
                    Console.WriteLine("clinicmanager role already exists");
                }
                #endregion

                #region Polyclinic Manager Role
                var polyclinicManagerRole = roleMgr.FindByNameAsync(SystemRoles.POLYCLINICMANAGER).Result;
                if (polyclinicManagerRole == null)
                {
                    var result = roleMgr.CreateAsync(new ApplicationRole
                    {
                        Name = SystemRoles.POLYCLINICMANAGER,
                        NormalizedName = SystemRoles.POLYCLINICMANAGER.ToUpper(),
                        IsSystemRole = true
                    }).Result;

                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }                   

                    Console.WriteLine("polyclinicmanager role created");
                }
                else
                {
                    Console.WriteLine("polyclinicmanager role already exists");
                }
                #endregion

                #region Pharmacy Manager Role
                var pharmacyManagerRole = roleMgr.FindByNameAsync(SystemRoles.PHARMACYMANAGER).Result;
                if (pharmacyManagerRole == null)
                {
                    var result = roleMgr.CreateAsync(new ApplicationRole
                    {
                        Name = SystemRoles.PHARMACYMANAGER,
                        NormalizedName = SystemRoles.PHARMACYMANAGER.ToUpper(),
                        IsSystemRole = true
                    }).Result;

                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }

                    Console.WriteLine("pharmacymanager role created");
                }
                else
                {
                    Console.WriteLine("pharmacymanager role already exists");
                }
                #endregion

                #region Sonar Manager Role
                var sonarManagerRole = roleMgr.FindByNameAsync(SystemRoles.SONARMANAGER).Result;
                if (sonarManagerRole == null)
                {
                    var result = roleMgr.CreateAsync(new ApplicationRole
                    {
                        Name = SystemRoles.SONARMANAGER,
                        NormalizedName = SystemRoles.SONARMANAGER.ToUpper(),
                        IsSystemRole = true
                    }).Result;

                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }

                    Console.WriteLine("sonarmanager role created");
                }
                else
                {
                    Console.WriteLine("sonarmanager role already exists");
                }
                #endregion    

                #region Doctor Role
                var doctorRole = roleMgr.FindByNameAsync(SystemRoles.DOCTOR).Result;
                if (doctorRole == null)
                {
                    var result = roleMgr.CreateAsync(new ApplicationRole
                    {
                        Name = SystemRoles.DOCTOR,
                        NormalizedName = SystemRoles.DOCTOR.ToUpper(),
                        IsSystemRole = true
                    }).Result;

                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }

                    Console.WriteLine("doctor role created");
                }
                else
                {
                    Console.WriteLine("doctor role already exists");
                }
                #endregion    

                #region Secretary Role
                var secretaryRole = roleMgr.FindByNameAsync(SystemRoles.SECRETARY).Result;
                if (secretaryRole == null)
                {
                    var result = roleMgr.CreateAsync(new ApplicationRole
                    {
                        Name = SystemRoles.SECRETARY,
                        NormalizedName = SystemRoles.SECRETARY.ToUpper(),
                        IsSystemRole = true
                    }).Result;

                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }

                    Console.WriteLine("secretary role created");
                }
                else
                {
                    Console.WriteLine("secretary role already exists");
                }
                #endregion    

                #region Lab Manager Role
                var labManagerRole = roleMgr.FindByNameAsync(SystemRoles.LABMANAGER).Result;
                if (labManagerRole == null)
                {
                    var result = roleMgr.CreateAsync(new ApplicationRole
                    {
                        Name = SystemRoles.LABMANAGER,
                        NormalizedName = SystemRoles.LABMANAGER.ToUpper(),
                        IsSystemRole = true
                    }).Result;

                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }

                    Console.WriteLine("lab manager role created");
                }
                else
                {
                    Console.WriteLine("lab manager role already exists");
                }
                #endregion    

                #region Beauty Center Manager Role
                var beautyCenterManagerRole = roleMgr.FindByNameAsync(SystemRoles.BEAUTYCENTERMANAGER).Result;
                if (beautyCenterManagerRole == null)
                {
                    var result = roleMgr.CreateAsync(new ApplicationRole
                    {
                        Name = SystemRoles.BEAUTYCENTERMANAGER,
                        NormalizedName = SystemRoles.BEAUTYCENTERMANAGER.ToUpper(),
                        IsSystemRole = true
                    }).Result;

                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }

                    Console.WriteLine("beauty center manager role created");
                }
                else
                {
                    Console.WriteLine("beauty center role already exists");
                }
                #endregion    

                #region HomeCare Role
                var homeCareRole = roleMgr.FindByNameAsync(SystemRoles.HOMECAREMANAGER).Result;
                if (homeCareRole == null)
                {
                    var result = roleMgr.CreateAsync(new ApplicationRole
                    {
                        Name = SystemRoles.HOMECAREMANAGER,
                        NormalizedName = SystemRoles.HOMECAREMANAGER.ToUpper(),
                        IsSystemRole = true
                    }).Result;

                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }

                    Console.WriteLine("home care manager role created");
                }
                else
                {
                    Console.WriteLine("home care role already exists");
                }
                #endregion    

                #region CALLCENTER Role
                var callCenterRole = roleMgr.FindByNameAsync(SystemRoles.CALLCENTER).Result;
                if (callCenterRole == null)
                {
                    var result = roleMgr.CreateAsync(new ApplicationRole
                    {
                        Name = SystemRoles.CALLCENTER,
                        NormalizedName = SystemRoles.CALLCENTER.ToUpper(),
                        IsSystemRole = true
                    }).Result;

                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }

                    Console.WriteLine("call center manager role created");
                }
                else
                {
                    Console.WriteLine("call center role already exists");
                }
                #endregion                  

                #region MEDICALTOURISM Role
                var medicalTourismRole = roleMgr.FindByNameAsync(SystemRoles.MEDICALTOURISM).Result;
                if (medicalTourismRole == null)
                {
                    var result = roleMgr.CreateAsync(new ApplicationRole
                    {
                        Name = SystemRoles.MEDICALTOURISM,
                        NormalizedName = SystemRoles.MEDICALTOURISM.ToUpper(),
                        IsSystemRole = true
                    }).Result;

                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }

                    Console.WriteLine("medicalTourism role created");
                }
                else
                {
                    Console.WriteLine("medicalTourism already exists");
                }
                #endregion   
            }
        }
    }
}

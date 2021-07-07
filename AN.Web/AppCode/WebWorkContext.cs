using AN.Core;
using AN.Core.Enums;
using AN.Core.Models;
using AN.Core.Resources.EntitiesResources.Role;
using AN.Core.Resources.UI.AdminPanel;
using AN.DAL;
using AN.Web.Helper;
using AN.Web.Helper.TokenParser;
using IdentityModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Shared.Constants;
using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AN.Web.App_Code
{
    /// <summary>
    /// Represents work context for web application
    /// </summary>
    public partial class WebWorkContext : IWorkContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITokenParser _tokenParser;
        private readonly BanobatDbContext _dbContext;
        public WebWorkContext(IHttpContextAccessor httpContextAccessor, ITokenParser tokenParser, BanobatDbContext dbContext)
        {
            _httpContextAccessor = httpContextAccessor;
            _tokenParser = tokenParser;
            _dbContext = dbContext;
        }

        private HttpContext _httpContext;
        public HttpContext MyHttpcontext => _httpContext ?? (_httpContext = _httpContextAccessor.HttpContext);

        public IdentityApplicationUser IdentityUser
        {
            get
            {
                var accessToken = _httpContextAccessor.HttpContext.GetTokenAsync("access_token").GetAwaiter().GetResult();
                return _tokenParser.ParseToken(accessToken);
            }
        }

        public string CurrentUserId => MyHttpcontext.User.Claims.Where(x => x.Type == JwtClaimTypes.Subject).Select(x => x.Value).FirstOrDefault();

        public string CurrentUserName => MyHttpcontext.User.Claims.Where(x => x.Type == JwtClaimTypes.PreferredUserName).Select(x => x.Value).FirstOrDefault();

        private string _loginAsClaim;
        public string LoginAsClaim => _loginAsClaim ?? (_loginAsClaim = MyHttpcontext.User.Claims.FirstOrDefault(x => x.Type == "LoginAs")?.Value);

        private string _personIdClaim;
        public string PersonIdClaim => _personIdClaim ?? (_personIdClaim = MyHttpcontext.User.Claims.FirstOrDefault(x => x.Type == "PersonId")?.Value);

        private string _centerIdClaim;
        public string CenterIdClaim => _centerIdClaim ?? (_centerIdClaim = MyHttpcontext.User.Claims.FirstOrDefault(x => x.Type == "CenterId")?.Value);

        private List<string> _serviceSupplyIdsClaim;
        public List<string> ServiceSupplyIdsClaim => _serviceSupplyIdsClaim ?? (_serviceSupplyIdsClaim = MyHttpcontext.User.Claims.Where(x => x.Type == "ServiceSupplyIds")?.Select(x => x.Value).ToList());

        public bool UserIsInRole(string role)
        {
            return MyHttpcontext.User.IsInRole(role);
        }

        public LoginAs LoginAs
        {
            get
            {
                if (!string.IsNullOrEmpty(LoginAsClaim))
                {
                    Enum.TryParse(LoginAsClaim.ToUpper(), out LoginAs userLoginAs);

                    if (userLoginAs == LoginAs.ROOTADMIN) userLoginAs = LoginAs.ADMIN;

                    return userLoginAs;
                }
                return LoginAs.UNKNOWN;
            }
        }

        private WorkingAreaModel _cachedWorkingArea;
        public WorkingAreaModel WorkingArea
        {
            get
            {
                if (_cachedWorkingArea != null) return _cachedWorkingArea;

                var sessionPerson = MyHttpcontext.Session.GetString("CurrentUserPerson");
                CurrentUser currentUserPerson;
                if (!string.IsNullOrEmpty(sessionPerson))
                {
                    currentUserPerson = JsonConvert.DeserializeObject<CurrentUser>(sessionPerson);
                }
                else
                {
                    if (!string.IsNullOrEmpty(PersonIdClaim))
                    {
                        int.TryParse(PersonIdClaim, out int personId);

                        var person = _dbContext.Persons.Find(personId);

                        currentUserPerson = new CurrentUser
                        {
                            UserId = CurrentUserId,
                            UserName = CurrentUserName,
                            PersonId = personId,
                            Avatar = person.RealAvatar,
                            FullName = Lang == Lang.KU ? person.FullName_Ku : Lang == Lang.AR ? person.FullName_Ar : person.FullName
                        };

                        MyHttpcontext.Session.SetString("CurrentUserPerson", JsonConvert.SerializeObject(currentUserPerson));
                    }
                    else
                    {
                        currentUserPerson = new CurrentUser
                        {
                            UserId = CurrentUserId,
                            UserName = CurrentUserName,
                            Avatar = "/images/avatars/NoAvatar.jpg",
                            FullName = LoginAs == LoginAs.ADMIN ? RolesResource.admin : ""
                        };
                    }
                }

                switch (LoginAs)
                {
                    case LoginAs.ADMIN:
                        {
                            if ((CurrentUserName == "admin" || CurrentUserName == "rootadmin") && string.IsNullOrEmpty(PersonIdClaim))
                            {
                                currentUserPerson.Avatar = "/images/avatars/admin-icon-blue.jpg";
                            }
                            _cachedWorkingArea = new WorkingAreaModel
                            {
                                LoginAs = LoginAs.ADMIN,
                                Name = "Admin",
                                SystemTitle = PanelResource.AwroNoreManager,
                                UserTitle = PanelResource.AwroNoreManager,
                                CurrentUser = currentUserPerson
                            };
                        }
                        break;
                    case LoginAs.HOSPITALMANAGER:
                        if ((object)MyHttpcontext.Session.GetString("CurrentHospital") is WorkingAreaModel currentHospital)
                        {
                            _cachedWorkingArea = currentHospital;
                            _cachedWorkingArea.LoginAs = LoginAs.HOSPITALMANAGER;
                        }
                        break;
                    case LoginAs.CLINICMANAGER:
                        if ((object)MyHttpcontext.Session.GetString("CurrentClinic") is WorkingAreaModel currentClinic)
                        {
                            _cachedWorkingArea = currentClinic;
                            _cachedWorkingArea.LoginAs = LoginAs.CLINICMANAGER;
                        }
                        break;
                    case LoginAs.POLYCLINICMANAGER:
                    case LoginAs.SONARMANAGER:
                    case LoginAs.LABMANAGER:
                    case LoginAs.BEAUTYCENTERMANAGER:
                        {
                            var sessionShiftCenter = MyHttpcontext.Session.GetString("CurrentShiftCenter");
                            if (!string.IsNullOrEmpty(sessionShiftCenter))
                            {
                                _cachedWorkingArea = JsonConvert.DeserializeObject<WorkingAreaModel>(sessionShiftCenter);
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(CenterIdClaim))
                                {
                                    int.TryParse(CenterIdClaim, out int centerId);
                                    var shiftCenter = _dbContext.ShiftCenters.Find(centerId);
                                    if (shiftCenter != null)
                                    {
                                        var serviceSupplyIds = new List<int>();
                                        if (ServiceSupplyIdsClaim.Any())
                                        {
                                            foreach (var item in ServiceSupplyIdsClaim)
                                            {
                                                int.TryParse(item, out int serviceSupplyId);
                                                serviceSupplyIds.Add(serviceSupplyId);
                                            }
                                        }
                                        string systemTitle;
                                        if (LoginAs == LoginAs.SONARMANAGER)
                                        {
                                            systemTitle = RolesResource.sonarmanager;
                                        }
                                        else if (LoginAs == LoginAs.LABMANAGER)
                                        {
                                            systemTitle = RolesResource.labmanager;
                                        }
                                        else if (LoginAs == LoginAs.BEAUTYCENTERMANAGER)
                                        {
                                            systemTitle = RolesResource.beautycentermanager;
                                        }
                                        else
                                        {
                                            if (MyHttpcontext.User.IsInRole(SystemRoles.DOCTOR))
                                                systemTitle = RolesResource.doctor;
                                            else if (MyHttpcontext.User.IsInRole(SystemRoles.SECRETARY))
                                                systemTitle = RolesResource.secretary;
                                            else
                                                systemTitle = AN.Core.Resources.Global.Global.CenterManager;
                                        }
                                        _cachedWorkingArea = new WorkingAreaModel
                                        {
                                            Id = centerId,
                                            LoginAs = LoginAs,
                                            Name = Lang == Lang.KU ? shiftCenter.Name_Ku : Lang == Lang.AR ? shiftCenter.Name_Ar : shiftCenter.Name,
                                            ServiceSupplyIds = serviceSupplyIds,
                                            SystemTitle = systemTitle,
                                            UserTitle = systemTitle,
                                            CurrentUser = currentUserPerson
                                        };
                                        MyHttpcontext.Session.SetString("CurrentShiftCenter", JsonConvert.SerializeObject(_cachedWorkingArea));
                                    }
                                }
                            }
                        }
                        break;
                    case LoginAs.PHARMACYMANAGER:
                        {
                            var sessionPharmacy = MyHttpcontext.Session.GetString("CurrentPharmacy");
                            if (!string.IsNullOrEmpty(sessionPharmacy))
                            {
                                _cachedWorkingArea = JsonConvert.DeserializeObject<WorkingAreaModel>(sessionPharmacy);
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(CenterIdClaim))
                                {
                                    int.TryParse(CenterIdClaim, out int centerId);

                                    var pharmacy = _dbContext.Pharmacies.Find(centerId);

                                    if (pharmacy != null)
                                    {
                                        _cachedWorkingArea = new WorkingAreaModel
                                        {
                                            Id = centerId,
                                            LoginAs = LoginAs.PHARMACYMANAGER,
                                            Name = Lang == Lang.KU ? pharmacy.Name_Ku : Lang == Lang.AR ? pharmacy.Name_Ar : pharmacy.Name,
                                            SystemTitle = RolesResource.pharmacymanager,
                                            UserTitle = RolesResource.pharmacymanager,
                                            CurrentUser = currentUserPerson
                                        };

                                        MyHttpcontext.Session.SetString("CurrentPharmacy", JsonConvert.SerializeObject(_cachedWorkingArea));
                                    }
                                }
                            }
                        }
                        break;                   
                    default:
                        break;
                }

                return _cachedWorkingArea;
            }
        }

        public string CurrentCulture => CultureHelper.CurrentCulture;

        public string CurrentCultureName => CultureHelper.CurrentCultureName;

        public Lang Lang => CultureHelper.Lang;

        public string Locale
        {
            get
            {
                if (Lang == Lang.KU) return SupportedLangs.KU;
                else if (Lang == Lang.AR) return SupportedLangs.AR;
                else return SupportedLangs.EN;
            }
        }

        public string CurrentLanguage => Lang == Lang.EN ? "English" : Lang == Lang.AR ? "العربی" : "کوردی";

        public string CurrentLanguageAbbr => Lang == Lang.EN ? "e" : Lang == Lang.AR ? "ع" : "ک";
    }
}
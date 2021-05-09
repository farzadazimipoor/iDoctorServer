using AN.Core;
using AN.Core.Enums;
using AN.Core.Models;
using Shared.Enums;
using System;

namespace AN.WebAPI.Helpers
{
    public class ApiWorkContext : IWorkContext
    {
        public IdentityApplicationUser IdentityUser => throw new NotImplementedException();

        public string CurrentUserId => throw new NotImplementedException();

        public string CurrentUserName => throw new NotImplementedException();

        public LoginAs LoginAs => throw new NotImplementedException();

        public WorkingAreaModel WorkingArea => throw new NotImplementedException();

        public string CurrentCulture => throw new NotImplementedException();

        public Lang Lang => throw new NotImplementedException();

        public string Locale => throw new NotImplementedException();

        public string LoginAsClaim => throw new NotImplementedException();

        public string CurrentLanguage => throw new NotImplementedException();

        public string CurrentLanguageAbbr => throw new NotImplementedException();

        public bool UserIsInRole(string role)
        {
            throw new NotImplementedException();
        }
    }
}

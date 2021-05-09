using AN.Core.Enums;
using AN.Core.Models;
using Shared.Enums;

namespace AN.Core
{
    /// <summary>
    /// Represents work context
    /// </summary>
    public interface IWorkContext
    {
        IdentityApplicationUser IdentityUser { get; }

        string CurrentUserId { get; }

        string CurrentUserName { get; }

        string LoginAsClaim { get; }

        bool UserIsInRole(string role);

        LoginAs LoginAs { get; }

        WorkingAreaModel WorkingArea { get; }     

        string CurrentCulture { get; }

        Lang Lang { get; }

        string Locale { get; }

        string CurrentLanguage { get; }

        string CurrentLanguageAbbr { get; }
    }
}

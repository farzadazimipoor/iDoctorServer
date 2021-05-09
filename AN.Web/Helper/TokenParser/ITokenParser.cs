using AN.Core.Models;

namespace AN.Web.Helper.TokenParser
{
    public interface ITokenParser
    {
        IdentityApplicationUser ParseToken(string accessToken);
    }
}

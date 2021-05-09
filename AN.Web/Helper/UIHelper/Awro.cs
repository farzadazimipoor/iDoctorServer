using Microsoft.AspNetCore.Mvc.Rendering;

namespace AWRO.Helper.UIHelper
{
    public static class HTMLEditor
    {
        public static AwroFramework<TModel> AWRO<TModel>(this IHtmlHelper<TModel> html)
        {
            return new AwroFramework<TModel>(html);
        }
    }

}

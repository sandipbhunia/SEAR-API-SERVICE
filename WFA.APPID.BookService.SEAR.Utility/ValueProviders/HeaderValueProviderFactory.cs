using System.Web.Http.Controllers;
using System.Web.Http.ValueProviders;

namespace WFA.APPID.BookService.SEAR.Utility.ValueProviders
{
    public class HeaderValueProviderFactory : ValueProviderFactory
    {
        public override IValueProvider GetValueProvider(HttpActionContext actionContext)
        {
            return new HeaderValueProvider(actionContext.Request.Headers);
        }
    }
}
using System.Web;
using System.Web.Mvc;

namespace WFA.APPID.BookService.ServiceHost
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

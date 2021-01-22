using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using WFA.APPID.BookService.SEAR.Utility.Models;
using WFA.APPID.BookService.SEAR.Utility.ValueProviders;
using WFA.APPID.BookService.ServiceHost.Models;

namespace WFA.APPID.BookService.ServiceHost.Controllers
{
   public  interface IBookServiceController
    {
        IHttpActionResult SerachBook([FromHeader] RequestHeaders headers, BookSerachRequest bookSearchRequest);
    }
}

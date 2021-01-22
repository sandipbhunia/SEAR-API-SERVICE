using Microsoft.Practices.EnterpriseLibrary.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WFA.APPID.BookService.Interceptor;
using WFA.APPID.BookService.Interceptor.Logging;
using WFA.APPID.BookService.SEAR.Utility;
using WFA.APPID.BookService.SEAR.Utility.Models;
using WFA.APPID.BookService.SEAR.Utility.ValueProviders;
using WFA.APPID.BookService.ServiceHost.BC;
using WFA.APPID.BookService.ServiceHost.Models;

namespace WFA.APPID.BookService.ServiceHost.Controllers
{
    public class BookServiceController : BaseApiController, IBookServiceController
    {
        [Route("V1")]
        [HttpPost]
        public IHttpActionResult SerachBook([FromHeader] RequestHeaders headers, BookSerachRequest bookSearchRequest)
        {
            SerachBookBC objBC = null;
            BookSerachRequest bookSearchResponse = null;
            TransactionLogEntry logEntry = new TransactionLogEntry();

            try {
                ValidateHeaderInfo();
                if (SystemErrors.Count > 0)
                {
                    bookSearchResponse = new BookSerachRequest();
                }
                else {
                    objBC = ResolveFactory.Get<SerachBookBC>(new object[] { logEntry });
                    var bcResponse = objBC.SearchBook(bookSearchRequest);
                }
            }
            catch (Exception ex)
            { }

            return Ok(bookSearchResponse);

        }
    }
}
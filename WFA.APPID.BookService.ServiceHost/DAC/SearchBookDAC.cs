using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WFA.APPID.BookService.Interceptor;
using WFA.APPID.BookService.Interceptor.Logging;
using WFA.APPID.BookService.ServiceHost.Models;

namespace WFA.APPID.BookService.ServiceHost.DAC
{
    public class SearchBookDAC : BaseDac
    {
        protected SearchBookDAC(TransactionLogEntry logEntry) : base(logEntry)
        {
        }
        [ServiceException(FaultCodeEnum.APP00000,"ERROR")]
        public virtual IList<Book> SearchBook(BookSerachRequest request)
        { 
            return new List<Book>();
        }
    }
}
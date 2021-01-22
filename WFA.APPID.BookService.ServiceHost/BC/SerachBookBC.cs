using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WFA.APPID.BookService.Interceptor;
using WFA.APPID.BookService.Interceptor.Logging;
using WFA.APPID.BookService.ServiceHost.DAC;
using WFA.APPID.BookService.ServiceHost.Models;

namespace WFA.APPID.BookService.ServiceHost.BC
{
    public class SerachBookBC : BaseBc
    {
        private readonly SearchBookDAC _searchBookDac;
        protected SerachBookBC(TransactionLogEntry logEntry) : base(logEntry)
        {
            _searchBookDac = ResolveFactory.Get<SearchBookDAC>(new object[] { LogEntry });
        }

        public virtual IList<Book> SearchBook(BookSerachRequest request)
        {
            return _searchBookDac.SearchBook(request);
        }
    }
}
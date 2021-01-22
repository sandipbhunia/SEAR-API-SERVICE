using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFA.APPID.BookService.Interceptor.Logging;

namespace WFA.APPID.BookService.Interceptor
{
    public interface IBaseHandler
    {
        TransactionLogEntry LogEntry { get; set; }
        WFFaultList_Type FaultList { get; set; }
        Object LoackObject { get; set; }

    }
}

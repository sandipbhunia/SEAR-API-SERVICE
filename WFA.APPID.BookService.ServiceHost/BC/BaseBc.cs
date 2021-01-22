using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WFA.APPID.BookService.Interceptor;
using WFA.APPID.BookService.Interceptor.Logging;
using WFA.APPID.BookService.SEAR.Utility.Models;

namespace WFA.APPID.BookService.ServiceHost.BC
{
    public class BaseBc : IBaseHandler
    {
        protected BaseBc(TransactionLogEntry logEntry )
        {
            var tempLogBc = new TransactionLogEntry();
            LogEntry = tempLogBc;
            FaultList = new WFFaultList_Type();
            LoackObject = new object();

        }
        public TransactionLogEntry LogEntry { get; set; }
        public WFFaultList_Type FaultList { get; set; }
        public object LoackObject { get; set; }

        protected Tuple<SystemErrorResponse, List<StatusMessage>> MapFaultsToResponse()
        {
            return new Tuple<SystemErrorResponse, List<StatusMessage>>(new SystemErrorResponse(), new List<StatusMessage>());
        }
    }
}
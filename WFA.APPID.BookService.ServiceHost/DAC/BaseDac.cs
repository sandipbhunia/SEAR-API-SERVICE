using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WFA.APPID.BookService.Interceptor;
using WFA.APPID.BookService.Interceptor.Logging;

namespace WFA.APPID.BookService.ServiceHost.DAC
{
    public class BaseDac:IBaseHandler
    {
        public TransactionLogEntry LogEntry { get; set; }
        public WFFaultList_Type FaultList { get; set; }
        public object LoackObject { get; set; }

        protected Database DB;
        private const string DefaultConnectionString = "ODSConnectionString";

        protected BaseDac(TransactionLogEntry logEntry)
        {
            var tempLogBc = new TransactionLogEntry();
            LogEntry = tempLogBc;
            FaultList = new WFFaultList_Type();
            LoackObject = new object();
           // var factory = new Microsoft.Practices.EnterpriseLibrary.Data.DatabaseProviderFactory();
            //DB = factory.Create(DefaultConnectionString);

        }
    }
}
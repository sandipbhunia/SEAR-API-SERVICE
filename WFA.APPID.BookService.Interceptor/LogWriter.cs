using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFA.APPID.BookService.Interceptor.Logging;

namespace WFA.APPID.BookService.Interceptor
{
    public static class LogWriter
    {
        public static void Write(TransactionLogEntry logEntry)
        {
            if (logEntry != null)
            {
                Microsoft.Practices.EnterpriseLibrary.Logging.Logger.Write(logEntry);
                if (logEntry.ExtendedProperties != null)
                {
                    logEntry.ExtendedProperties.Clear();
                }
                logEntry.Status = TransactionStatus.Fail;
                logEntry.ErrorCode = "None";
                logEntry.ErrorMessage = null;
                logEntry.Duration = 0;
                logEntry.ReturnRecordCount = null;
                logEntry.AffectedRecordCount = null;
            }
        }
    }
}

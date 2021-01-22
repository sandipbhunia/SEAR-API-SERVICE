using Microsoft.Practices.EnterpriseLibrary.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFA.APPID.BookService.Interceptor.Logging
{
    public class TransactionLogEntry : LogEntry
    {
        public TransactionLogEntry() { }
        public TransactionLogEntry(TransactionType transactionType, string loggingOperationName = null)
        {
            TransactionType = transactionType;
            LoggingOperationName = loggingOperationName;
        }
        public TransactionLogEntry(TransactionType transactionType,string version, string loggingOperationName = null)
        {
            TransactionType = transactionType;
            LoggingOperationName = loggingOperationName;
            Version = version;
        }
        public string LoggingSubAppId { get; set; }
        public string LoggingServiceName { get; set; }
        public string LoggingOperationName { get; set; }
        public string LoggingMethodName { get; set; }
        public string LoggingHostName { get; set; }
        public string LoggingApplicationName { get; set; }
        public string LoggingFunctionName { get; set; }
        public string CallingAppId { get; set; }
        public string CallingSubAppId { get; set; }
        public string CallingHostName { get; set; }

        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public string LoggingAppId { get; set; }
        public double Duration { get; set; }
        public DateTime StartTime { get; set; }
        public string RefToMessageId { get; set; }
        public string MessageId { get; set; }
        public string SenderMessageId { get; set; }
        public int? ReturnRecordCount { get; set; }
        public int? AffectedRecordCount { get; set; }
        public TransactionRecordType LogEntryType { get; set; }
        public string StatusCode { get; set; }
        public TransactionStatus Status { get; set; }
        public TransactionType TransactionType { get; set; }
        public string TransactionId { get; set; }
        public string SessionSequenceNumber { get; set; }
        public string SessionId { get; set; }
        public ProjectType ProjectType { get; set; }
        public string LoggedInPPID { get; set; }
        public string Version { get; set; }

    }

    public enum TransactionType
    { 
        None=0,
        Inquiry=1,
        Maintenance=2
    }

    public enum TransactionRecordType
    {
        None = 0,
        Detail = 1,
        Summary = 2
    }

    public enum TransactionStatus
    {
        None = 0,
        Fail = 1,
        Success = 2,
        PartialUpdate=3
    }
    public enum ProjectType
    {
        UX = 0,
        SOA = 1,
        BATCH = 2,
        SEAR = 3
    }

}

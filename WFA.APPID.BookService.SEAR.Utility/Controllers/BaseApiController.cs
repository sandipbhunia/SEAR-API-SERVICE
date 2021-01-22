using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using WFA.APPID.BookService.Interceptor.Logging;
using WFA.APPID.BookService.SEAR.Utility.Models;
using WFA.APPID.BookService.SEAR.Utility.Resources;

namespace WFA.APPID.BookService.SEAR.Utility
{
    public abstract class BaseApiController : ApiController
    {
        private List<SystemError> _systemErrors;
        public BaseApiController()
        {
            _systemErrors = new List<SystemError>();
        }
        protected List<SystemError> SystemErrors
        {
            get { return _systemErrors; }
        }

        protected void ValidateHeaderInfo()
        {
            var modelErrors = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var modelError in modelErrors)
            {
                if (modelError != null && modelError.ErrorMessage.ToUpper().StartsWith("WF_"))
                {
                    _systemErrors.Add(new SystemError
                    {
                        creatorApplicationId = MessageFormats.APP_ID,
                        code = "0000",
                        message = modelError.ErrorMessage
                    });
                }
            }
        }

        protected void AddSearResponseHeaders(HttpResponseHeaders responseHeaders, RequestHeaders requestHeaders, TransactionLogEntry logEntry)
        {
            responseHeaders.Add("APPID_HEADER", MessageFormats.APP_ID);
            responseHeaders.Add("SENDER_MSG_HEADER", logEntry.MessageId);
            responseHeaders.Add("SENDER_MSG__ECHO_HEADER", logEntry.SenderMessageId);
            responseHeaders.Add("HOSt_HEADER", Dns.GetHostName());
            responseHeaders.Add("CREATION_TIMESTAMP_HEADER", DateTime.Now.ToString("O"));

            if (!string.IsNullOrWhiteSpace(requestHeaders.transactionId))
            {
                responseHeaders.Add("TRAN_ID_HEADER", requestHeaders.transactionId);
            }
            if (!string.IsNullOrWhiteSpace(requestHeaders.sessionId))
            {
                responseHeaders.Add("SESSION_ID_HEADER", requestHeaders.sessionId);
            }
        }
        

    }
}

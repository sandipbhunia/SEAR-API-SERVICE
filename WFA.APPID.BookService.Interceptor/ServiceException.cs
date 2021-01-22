using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Interception.PolicyInjection.Pipeline;
using Unity.Interception.PolicyInjection.Policies;

namespace WFA.APPID.BookService.Interceptor
{
    public class ServiceException : HandlerAttribute
    {
        #region Properties
        private FaultCodeEnum ErrorCode { get; set; }
        private string ErrorMessage { get; set; }
        private FaultCaseEnum ErrorOccurence { get; set; }
        private bool InputLoggingReuired { get; set; }
        public int Order { get; set; }

        private bool IsLoggingNotReuired { get; set; }
        private bool IsExceptionHandlingNotRequired { get; set; }

        private bool IsFlowBreakReuired { get; set; }

        #endregion

        public ServiceException()
        { }

        public ServiceException(FaultCodeEnum errorCode, string errorMessage, FaultCaseEnum errorOccurence = FaultCaseEnum.Single,
    bool inputLoggingRequired = false, bool isLoggingNotRequired = false,
    bool isExceptionHandlingNotReuired = false, bool isFlowBreakReuired = false)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
            ErrorOccurence = errorOccurence;
            InputLoggingReuired = inputLoggingRequired;
            IsLoggingNotReuired = isLoggingNotRequired;
            IsExceptionHandlingNotRequired = isExceptionHandlingNotReuired;
            IsFlowBreakReuired = isFlowBreakReuired;
        }



        #region Create Handle Method
        public override ICallHandler CreateHandler(IUnityContainer container)
        {
            return new ServiceExCallHandler(ErrorCode, ErrorMessage, ErrorOccurence, InputLoggingReuired,
                IsLoggingNotReuired, IsExceptionHandlingNotRequired, IsFlowBreakReuired);
        }
        #endregion
    }
}

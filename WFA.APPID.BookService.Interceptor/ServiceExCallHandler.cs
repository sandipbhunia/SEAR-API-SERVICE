using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Unity.Interception.PolicyInjection.Pipeline;
using WFA.APPID.BookService.Interceptor.Logging;

namespace WFA.APPID.BookService.Interceptor
{
    public class ServiceExCallHandler : ICallHandler
    {
        #region Private variables

        private readonly object _lockObject = new object();
        #endregion
        #region Constructor
        public ServiceExCallHandler(FaultCodeEnum errorCode, string errorMessage, FaultCaseEnum errorOccurence,
            bool inputLoggingRequired, bool isLoggingNotRequired,
            bool isExceptionHandlingNotReuired, bool isFlowBreakReuired)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
            ErrorOccurence = errorOccurence;
            InputLoggingReuired = inputLoggingRequired;
            IsLoggingNotReuired = isLoggingNotRequired;
            IsExceptionHandlingNotRequired = isExceptionHandlingNotReuired;
            IsFlowBreakReuired = isFlowBreakReuired;
        }
        #endregion

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

        #region Methods

        public virtual IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            IMethodReturn methodReturn = getNext().Invoke(input, getNext);
            watch.Stop();
            TransactionLogEntry logEntry = null;
            WFFault_Type crnFault = null;
            IBaseHandler targetObject = input.Target as IBaseHandler;
            if (input.Arguments != null)
            {
                foreach (object arg in input.Arguments)
                {
                    if (arg != null && arg.GetType() == typeof(TransactionLogEntry))
                    {
                        logEntry = (TransactionLogEntry)arg;
                        break;
                    }
                }

            }

            if (logEntry == null)
            {
                if (targetObject != null)
                {
                    logEntry = targetObject.LogEntry;
                }
            }

            if (targetObject != null)
            {
                if (methodReturn.Exception != null)
                {
                    if (!IsExceptionHandlingNotRequired)
                    {
                        if (logEntry != null)
                        {
                            lock (_lockObject)
                            {
                                if (targetObject.FaultList == null)
                                {
                                    targetObject.FaultList = new WFFaultList_Type();
                                }
                                if (methodReturn.Exception.GetType().Name == "WfFaultException")
                                {
                                    WfFaultException fault = ((WfFaultException)(methodReturn.Exception));
                                    lock (targetObject.LoackObject)
                                    {
                                        targetObject.FaultList.AddRange(fault.Fault);
                                    }
                                }
                                else
                                {
                                    if (ErrorOccurence == (FaultCaseEnum.multiple))
                                    {
                                        string exceptionType = methodReturn.Exception.GetType().Name;
                                        if (methodReturn.Exception is OracleException)
                                        {
                                            exceptionType = "ORA" + ((OracleException)(methodReturn.Exception.GetBaseException())).Code;
                                        }
                                        crnFault = GetFaultCodeForMultiple(exceptionType, methodReturn.Exception);
                                        lock (targetObject.LoackObject)
                                        {
                                            targetObject.FaultList.Add(crnFault);
                                        }
                                    }
                                    else {
                                        crnFault = new WFFault_Type();

                                        lock (targetObject.LoackObject)
                                        {
                                            targetObject.FaultList.Add(crnFault);
                                        }
                                    }

                                }
                            }

                            logEntry.LoggingMethodName = input.MethodBase.ReflectedType.FullName +
                                "." + input.MethodBase.Name;
                            IDictionary<string, object> tempDict = logEntry.ExtendedProperties;
                            logEntry.ExtendedProperties = null;
                            var wfFaultException = new WfFaultException();
                            ExceptionPolicy.HandleException(wfFaultException, "SOAGenericExceptionPolicy");
                            logEntry.ExtendedProperties = tempDict;
                        }
                    }

                }

                if (!IsLoggingNotReuired)
                {
                    if (logEntry != null)
                    {
                        // TO DO:
                        logEntry.LoggingMethodName = input.MethodBase.ReflectedType.FullName + "." + input.MethodBase.Name;
                        logEntry.Status = (methodReturn.Exception == null) ? TransactionStatus.Success : TransactionStatus.Fail;
                        // TO DO:
                    }
                }
            }

            if (methodReturn.Exception != null && !IsFlowBreakReuired)
            {
                var methodInfo = input.MethodBase as MethodInfo;
                if (methodInfo != null && methodInfo.ReturnType != null && methodInfo.ReturnType.IsPrimitive)
                {
                    Type type = Type.GetType(methodInfo.ReturnType.FullName, true);
                    object instance = Activator.CreateInstance(type);
                    methodReturn = input.CreateMethodReturn(instance, input.Arguments);
                }
                else {
                    methodReturn = input.CreateMethodReturn(null, input.Arguments);
                }

            }
            return methodReturn;
        }

        private WFFault_Type GetFaultCodeForMultiple(string exceptionName, Exception exception)
        {
            string faultCode = ErrorCodes.ErrorCode.ResourceManager.GetString(exceptionName);
            if (faultCode == null)
            {
                faultCode = ErrorCode.ToString();
            }
            WFFault_Type faultObj = new WFFault_Type();
            return faultObj;
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFA.APPID.BookService.Interceptor.Logging;

namespace WFA.APPID.BookService.Interceptor
{
    public static class FaultHelper
    {
        public static WFFault_Type CreateFault()
        {
            return new WFFault_Type();
        }

        public static FaultType_Enum GetFaultType(string faultType)
        {
            FaultType_Enum fault = FaultType_Enum.APPL;

            return fault;
        }
        public static FaultSeverity_Enum GetFaultSeverity(string faultSeverity)
        {
            FaultSeverity_Enum severity = FaultSeverity_Enum.ERROR;

            return severity;
        }
    }
}

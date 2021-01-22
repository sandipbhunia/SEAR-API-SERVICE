using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WFA.APPID.BookService.Interceptor
{
    public enum FaultCaseEnum
    {
        [EnumMember]
        Single = 0,
        [EnumMember]
        multiple = 1
    }
}

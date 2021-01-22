using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFA.APPID.BookService.Interceptor.Logging;

namespace WFA.APPID.BookService.Interceptor
{
   public class WfFaultException:Exception
    {
        public List<WFFault_Type> Fault { get; set; }
    }
}

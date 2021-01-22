using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFA.APPID.BookService.SEAR.Utility.Models
{
  public  class SystemErrorResponse
    {
        public SystemErrorResponse()
        {
            SystemErrors = new List<SystemError>();
        }
        public IList<SystemError> SystemErrors { get; set; }
    }
}

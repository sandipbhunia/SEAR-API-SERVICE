using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFA.APPID.BookService.SEAR.Utility.Models
{
    public sealed class SystemError
    {
        public string creatorApplicationId { get; set; }
        public string creatorSubApplicationId { get; set; }
        public string code { get; set; }
        public string subCode { get; set; }
        public string message { get; set; }

        public string cause { get; set; }
        public SystemErrorDiagnostics diagnostics { get; set; }

    }
}

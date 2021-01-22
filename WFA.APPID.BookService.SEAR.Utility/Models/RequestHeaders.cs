using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFA.APPID.BookService.SEAR.Utility.Models
{
   public class RequestHeaders:CoreHeaders
    {
        [MinLength(3, ErrorMessage ="Should be atleast 3 character long")]
        public string senderSubApplicationId { get; set; }
        public string businessProcessId { get; set; }
        public string onBehalfOfId { get; set; }
        public DateTime emulateTestdateTime { get; set; }

        public string customerId { get; set; }

        public string teamMemberId { get; set; }
    }
}

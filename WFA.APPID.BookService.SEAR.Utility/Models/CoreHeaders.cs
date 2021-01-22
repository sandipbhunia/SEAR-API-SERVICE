using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFA.APPID.BookService.SEAR.Utility.Models
{
    public class CoreHeaders
    {
        [Required(ErrorMessage = "senderMessageId header is missing")]
        public string senderMessageId { get; set; }
        [Required(ErrorMessage = "creationTimeStamp header is missing")]
        public DateTime creationTimeStamp { get; set; }
        [Required(ErrorMessage = "senderApplicationId header is missing")]
        public string senderApplicationId { get; set; }
        [Required(ErrorMessage = "senderHostName header is missing")]
        public string senderHostName { get; set; }
        [Required(ErrorMessage = "sessionId header is missing")]
        public string sessionId { get; set; }

        [Required(ErrorMessage = "transactionId header is missing")]
        public string transactionId { get; set; }

    }
}

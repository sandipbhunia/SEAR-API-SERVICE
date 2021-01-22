using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFA.APPID.BookService.SEAR.Utility.Models
{
    public class StatusMessage
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public Type type { get; set; }

        public string code { get; set; }

        public string subCode { get; set; }

        public string message { get; set; }

        public string items { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.ValueProviders;

namespace WFA.APPID.BookService.SEAR.Utility.ValueProviders
{
    public class HeaderValueProvider : IValueProvider
    {
        private readonly HttpRequestHeaders _headers;
        public HeaderValueProvider(HttpRequestHeaders headers)
        {
            _headers = headers;
        }
        public bool ContainsPrefix(string prefix)
        {
            return true;
        }

        public ValueProviderResult GetValue(string key)
        {
            IEnumerable<string> values;
            var propName = RemovePrefixes(key);
            var headerName = MakeHeaderName(propName);
            if (!_headers.TryGetValues(headerName, out values))
            {
                return null;
            }
            var data = string.Join(",", values.ToArray());
            return new ValueProviderResult(values, data, CultureInfo.InvariantCulture);

        }

        private static string RemovePrefixes(string key)
        {
            var lastDot = key.LastIndexOf('.');
            if (lastDot == -1) return key;

            return key.Substring(lastDot + 1);
        }
        private static string MakeHeaderName(string propName)
        {
            return "WF" + propName;
        }
    }
}

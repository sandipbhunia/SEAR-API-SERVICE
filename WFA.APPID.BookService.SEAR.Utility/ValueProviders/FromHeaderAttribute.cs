using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;
using System.Web.Http.ValueProviders;

namespace WFA.APPID.BookService.SEAR.Utility.ValueProviders
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Parameter, Inherited = true, AllowMultiple = false)]
    public class FromHeaderAttribute : ParameterBindingAttribute
    {
        public override HttpParameterBinding GetBinding(HttpParameterDescriptor parameter)
        {
            if (parameter == null) throw new ArgumentNullException("parameter");
            var httpConfig = parameter.Configuration;
            var binder = new ModelBinderAttribute().GetModelBinder(httpConfig, parameter.ParameterType);
            return new ModelBinderParameterBinding(parameter, binder, new ValueProviderFactory[] { new HeaderValueProviderFactory() }); 
        }
    }
}

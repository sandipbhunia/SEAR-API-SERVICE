using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WFA.APPID.BookService.ServiceHost
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
           
            GlobalConfiguration.Configure(WebApiConfig.Register);
            #region SET LOGGER
            var configurationSource = ConfigurationSourceFactory.Create();
            var factory = new ExceptionPolicyFactory(configurationSource);
            var logWriterFactory = new LogWriterFactory(configurationSource);
            var logWriter = logWriterFactory.Create();
           // var exceptionmanager = factory.Create();
            
            #endregion
        }
    }
}

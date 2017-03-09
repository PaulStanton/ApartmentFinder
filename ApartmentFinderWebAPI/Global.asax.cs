using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net.Http.Formatting;
using System.Web.Routing;
using NLog;

namespace ApartmentFinderWebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            NLogConfig.logger.Trace("web service started");
            NLogConfig.logger.Log(LogLevel.Info,"started web service");
            GlobalConfiguration.Configure(WebApiConfig.Register);
            var rhm = new RequestHeaderMapping("Accept", "text/html",
                StringComparison.InvariantCultureIgnoreCase, true, "application/json");
               
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.MediaTypeMappings.Add(rhm); 
        }
    }
}

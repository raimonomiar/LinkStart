using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json;

namespace LinkStart.App_Start
{
    public class WebApiConfig
    {
         public static void Register(HttpConfiguration configuration)
         {
             var settings = GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings;

             settings.Formatting = Formatting.Indented;

             configuration.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}",
                new { id = RouteParameter.Optional });
        }
    }
}
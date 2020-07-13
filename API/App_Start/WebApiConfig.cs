using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace API
{
    public static class WebApiConfig
    {
       

        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            
         //   config.EnableCors();מחקתי כי זה הפריע לתעבורת נתונים!
        //    config.EnableCors(new EnableCorsAttribute(Properties.Settings.Default.Cors, "", ""));
         //   app.UseCors(CorsOptions.AllowAll);
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}

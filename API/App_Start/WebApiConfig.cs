using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using DAL;

namespace API
{
    public static class WebApiConfig
    {
    

        public static void Register(HttpConfiguration config)
        {


            var corsAttr = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(corsAttr);
            // Web API configuration and services

            config.EnableCors();
            //; מחקתי כי זה הפריע לתעבורת נתונים!
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

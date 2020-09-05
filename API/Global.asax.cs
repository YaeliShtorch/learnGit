using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using System.Web.Http.Cors;

namespace API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
          
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //var context = HttpContext.Current;
            //var response = context.Response;

            //// enable CORS
            //response.AddHeader("Access-Control-Allow-Origin", "*");
            //response.AddHeader("X-Frame-Options", "ALLOW-FROM *");

            //if (context.Request.HttpMethod == "OPTIONS")
            //{
            //    response.AddHeader("Access-Control-Allow-Methods", "GET, POST");
            //    response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept");
            //    response.AddHeader("Access-Control-Max-Age", "1728000");
            //    response.End();
            //}
            // Response.AppendHeader("Access-Control-Allow-Origin", "*");
            //HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
            //HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "*");
        }
        //protected void Application_BeginRequest()
        //{
        //    string[] allowedOrigin = new string[] { "http://localhost:2051", "http://localhost:2052" };
        //    var origin = HttpContext.Current.Request.Headers["Origin"];
        //    if (origin != null && allowedOrigin.Contains(origin))
        //    {
        //        HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", origin);
        //        HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET,POST");
        //    }
        //}

       // protected void Application_BeginRequest(object sender, EventArgs e)
       //{
       //     if (Context.Request.Path.Contains("api/") && Context.Request.HttpMethod == "OPTIONS")
       //     { 
       //         Context.Response.AddHeader("Access-Control-Allow-Origin", "*");

       //         Context.Response.AddHeader("Access-Control-Allow-Headers", "*");

       //         Context.Response.AddHeader("Access-Control-Allow-Methods", "*");

       //         Context.Response.AddHeader("Access-Control-Allow-Credentials", "true");

       //         Context.Response.End();
       //     }
       //     if (Context.Request.Path.Contains("api/") && Context.Request.HttpMethod == "POST")
       //     {
       //         Context.Response.AddHeader("Access-Control-Allow-Origin", "http://localhost:4200");
       //     }
       //     if (Context.Request.Path.Contains("api/") && Context.Request.HttpMethod == "GET")
       //     {
       //         Context.Response.AddHeader("Access-Control-Allow-Origin", "http://localhost:4200");
       //     }
       // }


        //public j Application_BeginRequest(object sender, EventArgs e)
        //{
        //    string httpOrigin = Request.Params["HTTP_ORIGIN"];
        //    if (httpOrigin == null) httpOrigin = "*";
        //    HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", httpOrigin);
        //    HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS");
        //    HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept, X-Token, Authorization");
        //    HttpContext.Current.Response.AddHeader("Access-Control-Allow-Credentials", "true");

        //    if (Request.HttpMethod == "OPTIONS")
        //    {
        //        HttpContext.Current.Response.StatusCode = 200;
        //        var httpApplication = sender as HttpApplication;
        //        httpApplication.CompleteRequest();
        //    }
        //}


    }
}


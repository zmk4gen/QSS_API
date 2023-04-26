using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace QSSAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();
            //config.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //config.Routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //config.Routes.MapHttpRoute(
            //name: "api",
            //routeTemplate: "api/{controller}/{action}/{id}",
            //      defaults: new { id = RouteParameter.Optional }
            ////defaults: new { controller = "Menu", action = "GetMajorGroup" }

            //);
            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);


            //Customized ROute
            config.Routes.MapHttpRoute(
                name: "api",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { name = RouteParameter.Optional, password = RouteParameter.Optional }
            );
            //Default Route
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}

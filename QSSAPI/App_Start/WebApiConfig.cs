using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Routing;

namespace QSSAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            //config.MapHttpAttributeRoutes();
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


            ////Customized ROute
            //config.Routes.MapHttpRoute(
            //    //name: "api",
            //    //routeTemplate: "api/{controller}/{action}/{id}",
            //    //defaults: new { name = RouteParameter.Optional, password = RouteParameter.Optional }
            //    name: "ActionApi",
            //    routeTemplate: "api/{controller}/{action}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
            //Default Route
            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            //config.MapHttpAttributeRoutes();

            //// define route
            //IHttpRoute defaultRoute = config.Routes.CreateRoute("api/{controller}/{id}",
            //                                    new { id = RouteParameter.Optional }, null);

            //// Add route
            //config.Routes.Add("DefaultApi", defaultRoute);

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
               name: "DefaultApi",
               routeTemplate: "api/{controller}/{id}",
               defaults: new { id = RouteParameter.Optional }
           );

            config.Routes.MapHttpRoute(
                name: "DefaultApiWithAction",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}

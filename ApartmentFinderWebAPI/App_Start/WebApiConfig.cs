﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ApartmentFinderWebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            
            config.MapHttpAttributeRoutes();
            config.EnableCors();

            /*config.EnableCors();
                        config.Routes.MapHttpRoute(
                            name: "DefaultApi",
                            routeTemplate: "api/{controller}/{id}",
                            defaults: new { id = RouteParameter.Optional }
                        ); */
            /*    config.Routes.MapHttpRoute(
                    name: "API Default",
                    routeTemplate: "api/{controller}/{method}",
                    defaults: new { method = RouteParameter.Optional }
                ); */

/*
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            ); */
        /*    config.Routes.MapHttpRoute(
                name: "API Default",
                routeTemplate: "api/{controller}/{method}",
                defaults: new { method = RouteParameter.Optional }
            ); */

            config.Routes.MapHttpRoute(
                name: "ControllerOnly",
                routeTemplate: "api/{controller}"
            );

            // Controller with ID
            // To handle routes like `/api/VTRouting/1`
            config.Routes.MapHttpRoute(
                name: "ControllerAndId",
                routeTemplate: "api/{controller}/{id}",
                defaults: null,
                constraints: new { id = @"^\d+$" } // Only integers 
            );

            // Controllers with Actions
            // To handle routes like `/api/VTRouting/route`
            config.Routes.MapHttpRoute(
                name: "ControllerAndAction",
                routeTemplate: "api/{controller}/{action}"
            );
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ApartmentFinderMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Initial",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Main", action = "Initial", id = UrlParameter.Optional }
            );
        }
    }
}
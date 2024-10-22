﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ATTT
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Weapon",
                url: "weapon/{action}/{id}",
                defaults: new { controller = "Weapon", action = "ListWeapon", id = UrlParameter.Optional },
                namespaces: new[] { "ATTT.Controllers" }
            );
            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "ATTT.Controllers" }
           );
        }
    }
}

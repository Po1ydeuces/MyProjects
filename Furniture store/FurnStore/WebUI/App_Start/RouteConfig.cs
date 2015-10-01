using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(null,
                            "",
                            new
                            {
                                controller = "Furniture",
                                action = "List",
                                section = (string)null,
                                page = 1
                            }
                        );

            routes.MapRoute(
                name: null,
                url: "Page{page}",
                defaults: new { controller = "Furniture", action = "List", section = (string)null },
                constraints: new { page = @"\d+" }
            );

            routes.MapRoute(null,
            "{section}",
            new { controller = "Furniture", action = "List", page = 1 }
            );

            routes.MapRoute(null,
                "{section}/Page{page}",
                new { controller = "Furniture", action = "List" },
                new { page = @"\d+" }
            );

            routes.MapRoute(null, "{controller}/{action}");


        }
    }
}

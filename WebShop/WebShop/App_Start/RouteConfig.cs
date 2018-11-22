using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebShop
{
    public class RouteConfig

    {
        public static int TimeSeePage = 0;
        

        public static void RegisterRoutes(RouteCollection routes)
        {
            TimeSeePage++;
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "có ID",
                url: "{Areas}/{controller}/{action}/{ID}",
                defaults: new { Areas = "User", controller = "About", action = "IntroducePost", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "ko ID",
                url: "{Areas}/{controller}/{action}",
                defaults: new { Areas = "User", controller = "News", action = "News", id = UrlParameter.Optional }
            );

           

        }

    }
}

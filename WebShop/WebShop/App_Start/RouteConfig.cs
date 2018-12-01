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
        public static void RegisterRoutes(RouteCollection routes)
        {
           routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
            routes.MapRoute(
               name: "sigleProduct",
               url: "san-pham/{metatitle}-{id}",
               defaults: new { Areas = "User", controller = "Product", action = "SingleProduct", id = UrlParameter.Optional }
           );
            routes.MapRoute(
               name: "san-pham-theo-thuong-hieu",
               url: "thuong-hieu/{metatitle}-{id}",
               defaults: new { Areas = "User", controller = "Product", action = "ShopByBrand", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "san-pham-theo-danh-muc",
               url: "danh-muc/{metatitle}-{id}",
               defaults: new { Areas = "User", controller = "Product", action = "ShopByBrand", id = UrlParameter.Optional }
           );

            routes.MapRoute(
             name: "thanh-toan",
             url: "thanh-toan",
             defaults: new { Areas = "User", controller = "Cart ", action = "Payment", id = UrlParameter.Optional }
         );
         

            /*  routes.MapRoute(
                name: "Default",
                url: "trang-chu/",
                defaults: new { Areas = "User", controller = "Product", action = "MainShop", id = UrlParameter.Optional },
                namespaces: new[] { "WebShop.Controllers" }
            );*/

            routes.MapRoute(
              name: "Default",
              url: "{controller}/{action}/{id}",
              defaults: new { Areas = "User", controller = "Product", action = "MainShop", id = UrlParameter.Optional},
              namespaces: new[] {"WebShop.Controllers"}
          );

        }

    }
}

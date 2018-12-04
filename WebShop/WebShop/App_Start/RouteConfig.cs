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
               defaults: new { controller = "Product", action = "SingleProduct", id = UrlParameter.Optional }
                , namespaces: new[] { "WebShop.Controllers" }
           );
            routes.MapRoute(
               name: "san-pham-theo-thuong-hieu",
               url: "thuong-hieu/{metatitle}-{id}",
               defaults: new { controller = "Product", action = "ShopByBrand", id = UrlParameter.Optional }
                , namespaces: new[] { "WebShop.Controllers" }
           );

            routes.MapRoute(
               name: "san-pham-theo-danh-muc",
               url: "danh-muc/{metatitle}-{id}",
               defaults: new { controller = "Product", action = "ShopByCategory", id = UrlParameter.Optional }
                , namespaces: new[] { "WebShop.Controllers" }
           );

            routes.MapRoute(
             name: "/thanh-toan",
             url: "thanh-toan",
             defaults: new { controller = "Cart ", action = "Payment" }
             , namespaces: new[] { "WebShop.Controllers" }

         );
            routes.MapRoute(
                name: "giới thiệu",
                url: "gioi-thieu",
                defaults: new { controller = "About", action = "IntroducePost", id = UrlParameter.Optional }
                 , namespaces: new[] { "WebShop.Controllers" }
            );
            routes.MapRoute(
               name: "tin tức",
               url: "tin-tuc",
               defaults: new { controller = "News", action = "news", id = UrlParameter.Optional }
                , namespaces: new[] { "WebShop.Controllers" }
           );
            routes.MapRoute(
               name: "lien hệ",
               url: "lien-he",
               defaults: new { controller = "Contact", action = "Contact", id = UrlParameter.Optional }
                , namespaces: new[] { "WebShop.Controllers" }
           );
            routes.MapRoute(
               name: "khuyen mãi",
               url: "khuyen-mai",
               defaults: new { controller = "Promotion", action = "Promotion", id = UrlParameter.Optional }
                , namespaces: new[] { "WebShop.Controllers" }
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
              defaults: new { controller = "Product", action = "MainShop", id = UrlParameter.Optional },
              namespaces: new[] { "WebShop.Controllers" }
          );

        }

    }
}

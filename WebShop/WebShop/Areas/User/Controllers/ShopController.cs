using System;
using System.Web.Mvc;
using WebShop_Model.Dao;


namespace WebShop.Areas.User.Controllers
{
    public class ShopController : Controller
    {[HttpGet]
        public ActionResult Shop()
        {
            ViewBag.ReviewProduct = new ProductDao().TakeProduct();
            ViewBag.totalRecord = new ProductDao().TakeTotalRecordProduct();
            return PartialView();
        }
        [ChildActionOnly]
        public ActionResult ShopSidebar()
        {
            ViewBag.SideBar = new CategoriesMenuDao().ListCategoryByStatus(true);
            ViewBag.Brands = new BrandsDao().TakeBrands();
            return PartialView();
        }



    }
}
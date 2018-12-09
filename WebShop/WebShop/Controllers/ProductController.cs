using System.Web.Mvc;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult ShopByBrand(int ID)
        {
            ViewBag.ReviewProduct = new Product().TakeProductByBrand(ID);
            ViewBag.totalRecord = new Product().TakeTotalRecordProductByBrand(ID);
            /* var model = new ProductDao().ListAllPageProductByBrand(ID,page, pageSize);*/
            return View();
        }

        public ActionResult ShopByCategory(int ID)
        {
            ViewBag.ReviewProduct = new Product().TakeProductByCategory(ID);
            ViewBag.totalRecord = new Product().TakeTotalRecordProductByCategory(ID);
            return View();
        }

        public ActionResult SingleProduct(int ID)
        {
            Product product = new Product();
            product.AddView(ID);
            ViewBag.SingleProduct = new Product().TakeProductID(ID);
            return View();
        }
        public ActionResult SearchProduct(string searchString)
        {
            ViewBag.searchProduct = new Product().SearchProduct(searchString);
            ViewBag.totalRecord = new Product().TakeTotalRecordProductBySearchProduct(searchString);
            return View();
        }

        
        public ActionResult MainShop()
        {
            ViewBag.ReviewProduct = new Product().TakeProduct();
            ViewBag.totalRecord = new Product().TakeTotalRecordProduct();
            return View();
        }
        [ChildActionOnly]
        public ActionResult ShopSidebar()
        {
            ViewBag.SideBar = new Menu().ListCategoryByStatus(true);
            ViewBag.Brands = new Brand().TakeBrands();
            return PartialView();
        }




    }
}
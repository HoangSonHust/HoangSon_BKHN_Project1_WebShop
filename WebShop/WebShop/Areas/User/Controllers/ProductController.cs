using System.Web.Mvc;
using WebShop_Model.Dao;
namespace WebShop.Areas.User.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult ShopByBrand(int ID)
        {
            ViewBag.ReviewProduct = new ProductDao().TakeProductByBrand(ID);
            /* var model = new ProductDao().ListAllPageProductByBrand(ID,page, pageSize);*/
            return View();
        }

        public ActionResult ShopByCategory(int ID)
        {
            ViewBag.ReviewProduct = new ProductDao().TakeProductByCategory(ID);
            return View();
        }

        public ActionResult SingleProduct(int ID)
        {
            ProductDao product = new ProductDao();
            product.AddView(ID);
            ViewBag.SingleProduct = new ProductDao().TakeProductID(ID);
            return View();
        }
        public ActionResult SearchProduct(string searchString, string Category)
        {
            ViewBag.searchProduct = new ProductDao().SearchProduct(searchString);
            return View();
        }

        public ActionResult test()
        {
            return View();
        }
        public ActionResult test1()
        {
            return View();
        }
    }
}
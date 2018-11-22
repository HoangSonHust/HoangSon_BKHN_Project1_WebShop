using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Areas.Common;
using WebShop.Areas.User.Models;
using WebShop_Model.Dao;
namespace WebShop.Areas.User.Controllers
{
    public class HeaderMainPageController : Controller
    {
      
        //lấy các menu trong MenuDao
        [ChildActionOnly]
        public ActionResult MainMenu()
        {
            var Model = new MenuDao().ListByGroupID(1);
            // var Model = 
            return PartialView(Model);
        }
        [ChildActionOnly]
        //lấy Category cho vào phần search
        public ActionResult Search()
        {
            var model = new CategoriesMenuDao().ListCategoryByStatus(true);

            return PartialView(model);
        }
        [ChildActionOnly]
        //lấy category cho vào sidebar
        public ActionResult CategoriesMenu()
        {
            var model = new CategoriesMenuDao().ListCategoryByStatus(true);
            return PartialView(model);

        }
        [ChildActionOnly]
        public PartialViewResult HeaderCart()
        {
            var cart = Session[ComonConstants.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            ViewBag.List = list;
            return PartialView();
        }

        [ChildActionOnly]
        //khi ta thu nhỏ kích thước màn hình thì nó hiện ra biểu tượng 3 cái ngang để hiển thị Menu
        public ActionResult PageMenu()
        {
            var Model = new MenuDao().ListByGroupID(1);
            return PartialView(Model);
        }
       

    }
}
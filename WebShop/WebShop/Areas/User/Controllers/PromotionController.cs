using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop_Model.Dao;
namespace WebShop.Areas.User.Controllers
{
    public class PromotionController : Controller
    {
        // GET: User/Promotion
        public ActionResult Promotion()
        {
            ViewBag.Promotion = new PromotionDao().TakePost();
            return View();
        }
        public ActionResult PromotionDetail(int ID)
        {
            ViewBag.PromotionDetail = new PromotionDao().TakeContent(ID);
            return View();
        }
    }
}
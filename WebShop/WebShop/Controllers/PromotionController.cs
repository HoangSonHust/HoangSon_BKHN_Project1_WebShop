using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class PromotionController : Controller
    {
        // GET: User/Promotion
        public ActionResult Promotion()
        {
            ViewBag.Promotion = new Promotion().TakePost();
            return View();
        }
        public ActionResult PromotionDetail(int ID)
        {
            ViewBag.PromotionDetail = new Promotion().TakeContent(ID);
            return View();
        }
    }
}
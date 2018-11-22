using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop_Model.Dao;
namespace WebShop.Areas.User.Controllers
{
    public class AboutController : Controller
    {
        public ActionResult IntroducePost(int ID)
        {
            ViewBag.DetailIntroduce = new AboutDao().TakeContent(ID);
            
            return View();
        }
    }
}
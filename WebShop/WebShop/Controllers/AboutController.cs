using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class AboutController : Controller
    {
        public ActionResult IntroducePost(int ID)
        {
            ViewBag.DetailIntroduce = new About().TakeContent(ID);
            
            return View();
        }
    }
}
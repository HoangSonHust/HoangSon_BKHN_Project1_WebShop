using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class NewsController : Controller
    {
        public ActionResult News()
        {
            ViewBag.News = new News().TakePost();
             return View();
        }
        public ActionResult DetailNews(int ID)
        {
            ViewBag.DetailNews = new News().TakeContent(ID);

            return View();
        }
    }
}
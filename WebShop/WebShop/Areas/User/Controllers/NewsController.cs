using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop_Model.Dao;
namespace WebShop.Areas.User.Controllers
{
    public class NewsController : Controller
    {
        public ActionResult News()
        {
            ViewBag.News = new NewsDao().TakePost();
             return View();
        }
        public ActionResult DetailNews(int ID)
        {
            ViewBag.DetailNews = new NewsDao().TakeContent(ID);

            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class ContactController : Controller
    {
        // GET: User/Contact
        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.ContactPost = new Contact().TakeContent(1);

            return View();
        }

       
    }
}
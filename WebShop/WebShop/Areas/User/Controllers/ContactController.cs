﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop_Model.Dao;
namespace WebShop.Areas.User.Controllers
{
    public class ContactController : Controller
    {
        // GET: User/Contact
        [HttpGet]
        public ActionResult Contact(int ID)
        {
            ViewBag.ContactPost = new ContactDao().TakeContent(ID);

            return View();
        }

        public ActionResult Contact2()
        {
        

            return View();
        }
        public ActionResult Contact3()
        {
            return View();
        }

        public ActionResult Contact4()
        {
            return View();
        }
    }
}
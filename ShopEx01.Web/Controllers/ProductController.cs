﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopEx01.Web.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Detail(int productId)
        {
            return View();
        }

        public ActionResult Category(int id)
        {
            return View();
        }
    }
}
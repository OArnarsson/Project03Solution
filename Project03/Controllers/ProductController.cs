using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project03.Models;

namespace Project03.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            ViewBag.Message = "This is the main page.";

            Category category = new Category();
            var model = category.GetAllProducts();
            return View(model);
        }


    }
}
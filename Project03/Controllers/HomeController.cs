using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project03.Models;

namespace Project03.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "This is the main page.";

            Category category = new Category();
            var model = category.GetAllProducts();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id != null)
            {
                Category category = new Category();
                var model = category.GetProductByID(Convert.ToInt32(id));
                return View(model);
            }

            else return View("NotFound");
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection formData)
        {
            Category category = new Category();
            Product prod = category.GetProductByID(id);
            if (prod != null)
            {
                UpdateModel(prod);
                category.UpdateProduct(prod);
                return RedirectToAction("Index");
            }
            else
            {
                return View("NotFound");
            }
        }

        public ActionResult Category(int CatId)
        {               
            Category category = new Category();
            var model = category.GetProductsByCategoryID(CatId);
            ViewBag.Active = CatId;
            return View("Index",model);
            
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Product());
        }        [HttpPost]
        public ActionResult Create(FormCollection formData)
        {
            Product prod = new Product();
            UpdateModel(prod);
            Category category = new Category();
            category.AddProduct(prod);
            return RedirectToAction("Index");
        }

    }
}
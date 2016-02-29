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
                PopulateDropDown();
                Category category = new Category();
                var model = category.GetProductByID(Convert.ToInt32(id));
                return View(model);
            }

            else return View("NotFound");
        }

        [HttpPost]
        public ActionResult Edit(Product prod)
        {
            Category category = new Category();
                if (ModelState.IsValid)
                {
                    UpdateModel(prod);
                    category.UpdateProduct(prod);
                    return RedirectToAction("Index");
                }
                else
                {
                PopulateDropDown();
                return View(prod);
                }
                
        }

        public ActionResult Category(int CatId)
        {
            Category category = new Category();
            var model = category.GetProductsByCategoryID(CatId);
            ViewBag.Categories = " : Category "+CatId;
            ViewBag.Active = CatId;
            
            return View("Index", model);

        }

        [HttpGet]
        public ActionResult Create()
        {
            PopulateDropDown();
            return View(new Product());
        }        [HttpPost]
        public ActionResult Create(Product model)
        {
            if (ModelState.IsValid)
            {

                Category category = new Category();
                category.AddProduct(model);
                
                return RedirectToAction("Index");
            }
            else
            {
                PopulateDropDown();
                return View(model);
            }
                
        }
        public void PopulateDropDown()
        {
            //Populate the available dropdown categories
            List<SelectListItem> categories = new List<SelectListItem>();
            SelectListItem item1 = new SelectListItem { Text = "Category1", Value = "1" };
            SelectListItem item2 = new SelectListItem { Text = "Category2", Value = "2" };
            SelectListItem item3 = new SelectListItem { Text = "Category3", Value = "3" };
            SelectListItem item4 = new SelectListItem { Text = "Category4", Value = "4" };
            SelectListItem item5 = new SelectListItem { Text = "Category5", Value = "5" };
            SelectListItem item6 = new SelectListItem { Text = "Category6", Value = "6" };
            SelectListItem item7 = new SelectListItem { Text = "Category7", Value = "7" };
            SelectListItem item8 = new SelectListItem { Text = "Category8", Value = "8" };

            categories.Add(item1);
            categories.Add(item2);
            categories.Add(item3);
            categories.Add(item4);
            categories.Add(item5);
            categories.Add(item6);
            categories.Add(item7);
            categories.Add(item8);
            // etc., add more items as needed
            ViewData["Categories"] = categories;
        }

    }
    }

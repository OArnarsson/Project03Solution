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
            GetCategoryName(CatId);

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

        public void GetCategoryName(int cat)
        {
            int caseSwitch = cat;
            switch (caseSwitch)
            {
                case 1:
                    ViewBag.Categories = "/Books & Audible";
                    ViewBag.Categories1 = "btn btn-info";
                    break;
                case 2:
                    ViewBag.Categories = "/Movies, Music & Games";
                    ViewBag.Categories2 = "btn btn-info";
                    break;
                case 3:
                    ViewBag.Categories = "/Electronics & Computers";
                    ViewBag.Categories3 = "btn btn-info";
                    break;
                case 4:
                    ViewBag.Categories = "/Home, Garden  & Tools";
                    ViewBag.Categories4 = "btn btn-info";
                    break;
                case 5:
                    ViewBag.Categories = "/Beauty, Health & Grocery";
                    ViewBag.Categories5 = "btn btn-info";
                    break;
                case 6:
                    ViewBag.Categories = "/Toys, Kids & Baby";
                    ViewBag.Categories6 = "btn btn-info";
                    break;
                case 7:
                    ViewBag.Categories = "/Clothing, Shoes & Jewelry";
                    ViewBag.Categories7 = "btn btn-info";
                    break;
                case 8:
                    ViewBag.Categories = "/Sport & Outdoors";
                    ViewBag.Categories8 ="btn btn-info";
                    break;
                case 9:
                    ViewBag.Categories = "/Automotive & Industrial";
                    ViewBag.Categories9 = "btn btn-info";
                    break;
                default:
                    ViewBag.Categories = "";
                    break;
            }
        }
        public void PopulateDropDown()
        {
            //Populate the available dropdown categories
            List<SelectListItem> categories = new List<SelectListItem>();
            SelectListItem item1 = new SelectListItem { Text = "Books & Audible", Value = "1" };
            SelectListItem item2 = new SelectListItem { Text = "Movies, Music & Games", Value = "2" };
            SelectListItem item3 = new SelectListItem { Text = "Electronics & Computers", Value = "3" };
            SelectListItem item4 = new SelectListItem { Text = "Home, Garden  & Tools", Value = "4" };
            SelectListItem item5 = new SelectListItem { Text = "Beauty, Health & Grocery", Value = "5" };
            SelectListItem item6 = new SelectListItem { Text = "Toys, Kids & Baby", Value = "6" };
            SelectListItem item7 = new SelectListItem { Text = "Clothing, Shoes & Jewelry", Value = "7" };
            SelectListItem item8 = new SelectListItem { Text = "Sport & Outdoors", Value = "8" };
            SelectListItem item9 = new SelectListItem { Text = "Automotive & Industrial", Value = "9" };

            categories.Add(item1);
            categories.Add(item2);
            categories.Add(item3);
            categories.Add(item4);
            categories.Add(item5);
            categories.Add(item6);
            categories.Add(item7);
            categories.Add(item8);
            categories.Add(item9);
            // etc., add more items as needed
            ViewData["Categories"] = categories;
        }

    }
    }

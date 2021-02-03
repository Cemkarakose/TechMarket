using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TechMarket.DAL;
using TechMarket.Models;

namespace TechMarket.Controllers
{
    public class ProductsController : Controller
    {
        private StoreContext db = new StoreContext();

        // GET: Products
        [Authorize(Roles = "Admin, Customer")]
        public ActionResult Index(string sortOrder, int? category)
        {
            ViewBag.Category = category;
            IEnumerable<Product> prods = db.products.Where(product => product.category == category);
            ViewBag.NextSortOrderBrand = sortOrder == null || sortOrder == "descendingBrand" ? "ascendingBrand" : "descendingBrand";
            ViewBag.NextSortOrderPrice = sortOrder == null || sortOrder == "descendingPrice" ? "ascendingPrice" : "descendingPrice";
            ViewBag.NextSortOrderModel = sortOrder == null || sortOrder == "descendingModel" ? "ascendingModel" : "descendingModel";
            switch (sortOrder)
            {
                case "ascendingBrand":
                    prods = prods.OrderBy(product => product.productbrand);
                    break;
                case "descendingBrand":
                    prods = prods.OrderByDescending(product => product.productbrand);
                    break;
                case "ascendingPrice":
                    prods = prods.OrderBy(product => product.price);
                    break;
                case "descendingPrice":
                    prods = prods.OrderByDescending(product => product.price);
                    break;
                case "ascendingModel":
                    prods = prods.OrderBy(product => product.productmodel);
                    break;
                case "descendingModel":
                    prods = prods.OrderByDescending(product => product.productmodel);
                    break;
                default:
                    break;
            }
            return View(prods.ToList());
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Customer")]
        public ActionResult Index(FormCollection collection)
        {
            string searchString = collection["searchString"];
            ViewBag.currentSearchString = searchString;
            var prods = db.products.Where(product => product.productbrand.Contains(searchString));
            return View(prods);
        }
        // GET: Products/Details/5
        [Authorize(Roles = "Admin, Customer")]
        public ActionResult Details(int id)
        {
            var prod = db.products.Single(obj => obj.productid == id);
            return View(prod);
        }

        // GET: Products/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Product newProduct = new Product { category = int.Parse(collection["category"]), productbrand = collection["productbrand"], productmodel = collection["productmodel"], stock = int.Parse(collection["stock"]), price = double.Parse(collection["price"]) };
                db.products.Add(newProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            var prod = db.products.Single(obj => obj.productid == id);
            return View(prod);
        }

        // POST: Movie/Edit/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                var prod = db.products.Single(obj => obj.productid == id);
                prod.category = int.Parse(collection["category"]);
                prod.productbrand = collection["productbrand"];
                prod.productmodel = collection["productmodel"];
                prod.stock = int.Parse(collection["stock"]);
                prod.price = double.Parse(collection["price"]);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Movie/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            var prod = db.products.Single(obj => obj.productid == id);
            return View(prod);
        }

        // POST: Movie/Delete/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var prod = db.products.Find(id);
                db.products.Remove(prod);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

using ASPNET_InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPNET_InventoryManagement.Controllers
{
    public class ProductController : Controller
    {
        Inventory_managementEntities db = new Inventory_managementEntities();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DisplayProduct()
        {
            List<product> list = db.products.OrderByDescending(x => x.id).ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateProduct(product prod)
        {
            db.products.Add(prod);
            db.SaveChanges();
            return RedirectToAction("DisplayProduct");
        }

        [HttpGet]
        public ActionResult UpdateProduct(int id)
        {
            product pro = db.products.Where(x => x.id == id).SingleOrDefault();
            return View(pro);
        }

        [HttpPost]
        public ActionResult UpdateProduct(int id, product prod)
        {
            product pro = db.products.Where(x => x.id == id).SingleOrDefault();
            pro.product_name = prod.product_name;
            pro.product_qty = prod.product_qty;
            db.SaveChanges();
            return RedirectToAction("DisplayProduct");
        }

        [HttpGet]
        public ActionResult ProductDetail(int id)
        {
            product pro = db.products.Where(x => x.id == id).SingleOrDefault();
            return View(pro);
        }

        [HttpGet]
        public ActionResult DeleteProduct(int id)
        {
            product pro = db.products.Where(x => x.id == id).SingleOrDefault();
            return View(pro);
        }

        [HttpPost]
        public ActionResult DeleteProduct(int id, product prod)
        {
            product pro = db.products.Where(x => x.id == id).SingleOrDefault();
            db.products.Remove(pro);
            db.SaveChanges();
            return RedirectToAction("DisplayProduct");
        }
    }
}
using ASPNET_InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPNET_InventoryManagement.Controllers
{
    public class SaleController : Controller
    {
        Inventory_managementEntities db = new Inventory_managementEntities();

        // GET: Sale
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SaleDisplay()
        {
            List<sale> list = db.sales.OrderByDescending(x => x.id).ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult SaleProduct()
        {
            List<string> list = db.products.Select(x => x.product_name).ToList();
            ViewBag.ProductName = new SelectList(list);
            return View();
        }

        [HttpPost]
        public ActionResult SaleProduct(sale S)
        {
            db.sales.Add(S);
            db.SaveChanges();
            return RedirectToAction("SaleDisplay");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            sale S = db.sales.Where(x => x.id == id).SingleOrDefault();
            List<string> list = db.products.Select(x => x.product_name).ToList();
            ViewBag.ProductName = new SelectList(list);
            return View(S);
        }

        [HttpPost]
        public ActionResult Edit(int id, sale Sal)
        {
            sale S = db.sales.Where(x => x.id == id).SingleOrDefault();
            S.sale_date = Sal.sale_date;
            S.sale_prod = Sal.sale_prod;
            S.sale_qty = Sal.sale_qty;
            db.SaveChanges();
            return RedirectToAction("SaleDisplay");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            sale S = db.sales.Where(x => x.id == id).SingleOrDefault();
            return View(S);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            sale S = db.sales.Where(x => x.id == id).SingleOrDefault();
            return View(S);
        }

        [HttpPost]
        public ActionResult Delete(int id, sale Sal)
        {
            sale S = db.sales.Where(x => x.id == id).SingleOrDefault();
            db.sales.Remove(S);
            db.SaveChanges();
            return RedirectToAction("SaleDisplay");
        }
    }
}
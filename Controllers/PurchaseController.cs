using ASPNET_InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPNET_InventoryManagement.Controllers
{
    public class PurchaseController : Controller
    {
        Inventory_managementEntities db = new Inventory_managementEntities();

        // GET: Purchase
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult PurchaseDisplay()
        {
            List<purchase> list = db.purchases.OrderByDescending(x => x.id).ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult PurchaseProduct()
        {
            List<string> list = db.products.Select(x => x.product_name).ToList();
            ViewBag.ProductName = new SelectList(list);
            return View();
        }

        [HttpPost]
        public ActionResult PurchaseProduct(purchase pur)
        {
            db.purchases.Add(pur);
            db.SaveChanges();
            return RedirectToAction("PurchaseDisplay");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            purchase p = db.purchases.Where(x => x.id == id).SingleOrDefault();
            List<string> list = db.products.Select(x => x.product_name).ToList();
            ViewBag.ProductName = new SelectList(list);
            return View(p);
        }

        [HttpPost]
        public ActionResult Edit(int id, purchase pur)
        {
            purchase p = db.purchases.Where(x => x.id == id).SingleOrDefault();
            p.purchase_date = pur.purchase_date;
            p.purchase_prod = pur.purchase_prod;
            p.purchase_qty = pur.purchase_qty;
            db.SaveChanges();
            return RedirectToAction("PurchaseDisplay");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            purchase p = db.purchases.Where(x => x.id == id).SingleOrDefault();
            return View(p);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            purchase p = db.purchases.Where(x => x.id == id).SingleOrDefault();
            return View(p);
        }

        [HttpPost]
        public ActionResult Delete(int id, purchase pur)
        {
            purchase p = db.purchases.Where(x => x.id == id).SingleOrDefault();
            db.purchases.Remove(p);
            db.SaveChanges();
            return RedirectToAction("PurchaseDisplay");
        }
    }
}
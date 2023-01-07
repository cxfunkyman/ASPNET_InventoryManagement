using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPNET_InventoryManagement.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "ASP.NET Inventory Management System.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Seky Perez Moya";

            return View();
        }

        public ActionResult Help()
        {
            ViewBag.Message = "Development System Information";
            return View();
        }
    }
}
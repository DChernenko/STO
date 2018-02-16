using Newtonsoft.Json;
using STO.Domain.Concrete;
using STO.Domain.Entities;
using STO.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Script.Serialization;


namespace STO.WebUI.Controllers
{
    public class NavigationController : Controller
    {
        EFDbContext db = new EFDbContext("EFDbContext");
        // GET: Navigation
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult PViewTotalPrice()
        {
            object o = Convert.ToInt32(WebConfigurationManager.AppSettings["ListLastCars"]);
            List<TotalPrice> totalPrices = db.TotalPrices
                .Include(c => c.Car).Take(5).ToList();
            return PartialView("PViewTotalPrice", totalPrices);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {

            TotalPrice totalPrice = db.TotalPrices
                .Include(c => c.Car)
                .Include(l => l.CalculateCost)
                .Where(p => p.Id == id)
                .FirstOrDefault();
            return View(totalPrice);
        }
    }
}
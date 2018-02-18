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

        [HttpGet]
        [ChildActionOnly]
        public ActionResult PViewTotalPrice()
        {
            List<TotalPrice> totalPrices = db.TotalPrices
                .Include(c => c.Car).Take(Convert.ToInt32(WebConfigurationManager.AppSettings["ListLastCars"])).ToList();
            return PartialView("PViewTotalPrice", totalPrices);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            TotalPrice totalPrice = db.TotalPrices
                .Include(c => c.Car)
                .Include(l => l.CalculateCost)
                .FirstOrDefault(p => p.Id == id);
            return View(totalPrice);
        }
    }
}
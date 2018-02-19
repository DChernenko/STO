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
                .Include(c => c.Car.TypeCar)
                .Include(l => l.CalculateCost.Select(cc => cc.TypeService.Service))
                //.OrderBy(s => s.CalculateCost.OrderBy(t => t.TypeService.Service.IsAddService))
                .FirstOrDefault(p => p.Id == id);
            ViewBag.IsContainAddService = totalPrice?.CalculateCost.FirstOrDefault(s => s.TypeService.Service.IsAddService) != null;
            totalPrice?.CalculateCost.OrderBy(s => s.TypeService.Service.IsAddService);
            return View(totalPrice);
        }
    }
}
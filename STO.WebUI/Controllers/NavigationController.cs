using Newtonsoft.Json;
using STO.Domain.Concrete;
using STO.Domain.Entities;
using STO.WebUI.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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


        public ActionResult GetTotalPrices()
        {
            List<TotalPrice> totalPrices = db.TotalPrices.Include(c => c.Car).Take(5).ToList();
            return PartialView(totalPrices);
        }

        public ActionResult Details(int id)
        {

            TotalPrice totalPrice = db.TotalPrices.Include(c => c.Car).Include(l => l.CalculateCost).Where(p => p.Id == id).FirstOrDefault();
            return View(totalPrice);
        }
    }
}
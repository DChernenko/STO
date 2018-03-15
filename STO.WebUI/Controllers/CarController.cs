using System;
using Newtonsoft.Json;
using STO.Domain.Concrete;
using STO.Domain.Entities;
using STO.WebUI.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using STO.WebUI.Filters;

namespace STO.WebUI.Controllers
{
    [Culture]
    public class CarController : Controller
    {
        EFDbContext db = new EFDbContext("EFDbContext");

        public ActionResult Index()
        {
            //ViewBag.ListType = new SelectList(db.TypeCars.Select(c => new SelectListItem
            //{
            //    Value = c.Id.ToString(),
            //    Text = c.Name

            //}));
            ViewBag.ListType = new SelectList(db.TypeCars.ToList<TypeCar>(), "Id", "Name");



            return View();
        }

        public JsonResult GetServices(int? id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<TypeService> services = db.TypeServices
                .Include(p => p.Service)
                .Where(s => s.TypeCarId == id && s.Service.IsActive)
                .ToList();
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.Indented
            };
            string json = JsonConvert.SerializeObject(services, settings);
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public string AddData(AddDataAdapter addCar)
        {
            TotalPrice totalPrice = new TotalPrice();
            List<CalculateCost> list = new List<CalculateCost>(addCar.Services.Count);
            Car car = new Car();

            int state = Convert.ToInt32(WebConfigurationManager.AppSettings["State"]);
            foreach (KeyValuePair<int, int> lists in addCar.Services)
            {
                CalculateCost c = new CalculateCost();
                c.TotalPrice = totalPrice;
                c.State = state - lists.Value;
                c.Car = car;
                c.TypeService.TypeCarId = addCar.TypeCarId;
                c.TypeService.ServiceId = lists.Key;
                list.Add(c);
            }

            using (EFDbContext db = new EFDbContext())
            {
                db.Cars.Add(car);
                db.TotalPrices.Add(totalPrice);
                db.CalculateCostes.AddRange(list);
            }

            //Convert.ToInt32(WebConfigurationManager.AppSettings["State"])


            return "Спасибо"; ;
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
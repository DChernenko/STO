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
            int state = Convert.ToInt32(WebConfigurationManager.AppSettings["State"]);
            decimal price = Convert.ToDecimal(WebConfigurationManager.AppSettings["Price"]);
            TotalPrice totalPrice = new TotalPrice();
            List<CalculateCost> list = new List<CalculateCost>(addCar.Services.Count);
            Car car = db.Cars.SingleOrDefault(cars => cars.Number == addCar.NumberCar);
            if (car == null)
            {
                car = new Car();
                car.TypeCarId = addCar.TypeCarId;
                car.Number = addCar.NumberCar;
            }


            var listsCalculate = (from typeServices in db.TypeServices.ToList()
                                  join addCars in addCar.Services
                                  on typeServices.ServiceId equals addCars.Key
                                  where typeServices.TypeCarId == addCar.TypeCarId
                                          && typeServices.Service.IsActive
                                  select new
                                  {
                                      State = !typeServices.Service.IsAddService ? state - addCars.Value : state,
                                      TypeServiceId = typeServices.Id,
                                      Cost = !typeServices.Service.IsAddService ? addCars.Value * price : typeServices.Service.Cost
                                  });

            totalPrice.Total = listsCalculate.Sum(s => s.Cost);
            totalPrice.Date = DateTime.Now;
            totalPrice.Car = car;
            totalPrice.AvgState = listsCalculate.Average(s => s.State);
            foreach (var l in listsCalculate)
            {
                CalculateCost c = new CalculateCost();
                c.TotalPrice = totalPrice;
                c.State = l.State;
                c.Car = car;
                c.TypeServiceId = l.TypeServiceId;
                //c.TotalPriceId = totalPrice.Id;
                list.Add(c);
            }

            db.Cars.Add(car);
            db.TotalPrices.Add(totalPrice);
            db.Cars.Add(car);
            db.SaveChanges();

            //using (EFDbContext db1 = new EFDbContext())
            //{
            //    db1.Cars.Add(car);
            //    db1.TotalPrices.Add(totalPrice);
            //    db1.CalculateCostes.AddRange(list);
            //}            
            return "Спасибо"; ;
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
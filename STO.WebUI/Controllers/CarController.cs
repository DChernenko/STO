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
            ViewBag.ListType = new SelectList(db.TypeCars.ToList<TypeCar>(), "Id", "Name");
            return View();
        }

        public ActionResult GetServices(int? id)
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
                                      Cost = !typeServices.Service.IsAddService ? addCars.Value * price : typeServices.Service.Cost,
                                      IsAddService = typeServices.Service.IsAddService
                                  });

            totalPrice.Total = listsCalculate.Sum(s => s.Cost);
            totalPrice.Date = DateTime.Now;
            totalPrice.Car = car;
            totalPrice.AvgState = listsCalculate.Where(w => !w.IsAddService).Average(s => s.State);
            foreach (var l in listsCalculate)
            {
                CalculateCost c = new CalculateCost();
                c.TotalPrice = totalPrice;
                c.State = l.State;
                c.Car = car;
                c.TypeServiceId = l.TypeServiceId;
                list.Add(c);
            }
            db.Cars.Add(car);
            db.CalculateCostes.AddRange(list);
            db.TotalPrices.Add(totalPrice);
            db.Cars.Add(car);
            db.SaveChanges();

            //for shpw data
            var carInfos = (from cars in db.Cars
                            join totalPrices in db.TotalPrices on cars.Id equals totalPrices.CarId
                            join tpCar in db.TypeCars on cars.TypeCar.Id equals tpCar.Id
                            orderby totalPrices.Date descending
                            select new
                            {
                                CarId = cars.Id,
                                Number = cars.Number,
                                Total = totalPrices.Total,
                                TypeCar = tpCar.Id,
                                AvgState = totalPrice.AvgState,
                                Date = totalPrice.Date
                            }).Take(5);

            List<CarInfo> carInfoList = new List<CarInfo>(carInfos.Count());
            CarInfo tempCarInfo;
            foreach (var carinfo in carInfos)
            {
                var servicess = from calc in db.CalculateCostes
                                join tpService in db.TypeServices
                                on new { jProperty1 = (int)calc.TypeServiceId, jProperty2 = carinfo.TypeCar }
                                   equals new { jProperty1 = tpService.Id, jProperty2 = (int)tpService.TypeCarId }
                                join service in db.Services on tpService.ServiceId equals service.Id
                                where calc.CarId == carinfo.CarId
                                select new
                                {
                                    State = calc.State,
                                    IsAddService = service.IsAddService,
                                    ServiceName = service.Name,
                                    Cost = service.Cost
                                };
                tempCarInfo = new CarInfo()
                {
                    Services = new List<CarServiceInfo>(servicess.Count()),
                    Number = carinfo.Number,
                    Total = carinfo.Total,
                    TypeCar = carinfo.TypeCar
                };
                CarServiceInfo carServiceInfo;
                foreach (var service in servicess)
                {
                    carServiceInfo = new CarServiceInfo()
                    {
                        Cost = service.Cost,
                        IsAddService = service.IsAddService,
                        State = service.State,
                        ServiceName = service.ServiceName
                    };
                    tempCarInfo.Services.Add(carServiceInfo);
                }
                carInfoList.Add(tempCarInfo);
            }
            return "Спасибо";
        }
        [HttpGet]
        public ActionResult ShowCars()
        {
            var call = from car in db.Cars.Take(5)
                       join tpCar in db.TypeCars on car.TypeCar.Id equals tpCar.Id
                       join calc in db.CalculateCostes on car.Id equals calc.CarId
                       join tpService in db.TypeServices on new { jProperty1 = (int)calc.TypeServiceId, jProperty2 = tpCar.Id }
                                equals new { jProperty1 = tpService.Id, jProperty2 = (int)tpService.TypeCarId }
                       join service in db.Services on tpService.ServiceId equals service.Id
                       join totalPrice in db.TotalPrices on calc.TotalPriceId equals totalPrice.Id
                       where service.IsActive
                       orderby totalPrice.Date descending
                       select new
                       {
                           Number = car.Number,
                           TypeCar = tpCar.Name,
                           State = calc.State,
                           IsAddService = service.IsAddService,
                           ServiceName = service.Name,
                           Cost = service.Cost,
                           TotalPrice = totalPrice.Total
                       };


            return View();
        }





        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}


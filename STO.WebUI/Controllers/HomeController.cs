using Newtonsoft.Json;
using STO.Domain.Concrete;
using STO.Domain.DAL;
using STO.Domain.Entities;
using STO.WebUI.Models;
using STO.WebUI.Service;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace STO.WebUI.Controllers
{
    public class HomeController : Controller
    {
        EFDbContext db = new EFDbContext("EFDbContext");

        //private void SetFormContext() {
        //    if (this.ViewContext.FormContext == null)
        //    {
        //        this.ViewContext.FormContext = new FormContext();
        //    }
        //}

        public ActionResult GetCarViewModel()
        {
            return PartialView("Forms/CarFormView");
        }

        public ActionResult GetBusViewModel()
        {
            return PartialView("Forms/BusFormView");
        }

        public ActionResult GetTruckViewModel()
        {
            return PartialView("Forms/TruckFormView");
        }

        public ActionResult Index()
        {
            //var service = new Service<CarViewModel, Car>(new UnitOfWork());
            //var lists = service.GetLists();

            return View(db.TypeCars.ToList<TypeCar>());
        }



        //public JsonResult GetServices(int? id)
        //{
        //    db.Configuration.ProxyCreationEnabled = false;
        //    List<TypeService> services = db.TypeServices
        //        .Include(p => p.Service)
        //        .Where(s => s.TypeCarId == id && s.Service.IsActive)
        //        .ToList();
        //    JsonSerializerSettings settings = new JsonSerializerSettings
        //    {
        //        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
        //        Formatting = Formatting.Indented
        //    };
        //    string json = JsonConvert.SerializeObject(services, settings);
        //    return Json(json, JsonRequestBehavior.AllowGet);
        //}

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}

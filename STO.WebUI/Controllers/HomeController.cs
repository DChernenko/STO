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
    public class HomeController : Controller
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
        public string AddData(AddCar addCar)
        {

            return "Спасибо"; ;
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}

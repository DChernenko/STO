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
            if (id == null)
            {

            }
            //працює
            List<TypeService> services = db.TypeServices.Include(p => p.Service).Where(s => s.TypeCarId == id).ToList();

            var joinTables = db.TypeServices.Join(db.Services, t => t.ServiceId, s => s.Id,
                (t, s) => new { Id = s.Id, Name = s.Name, IsAddService = s.IsAddService, TypeCar = t.TypeCarId, IsActive = s.IsActive }).Where(t => t.TypeCar.Value == id).ToList();


            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.Indented
            };

            string json = JsonConvert.SerializeObject(services, settings);

            //List<TypeService> services2 = db.Services.Include(p => p.TypeServices).Where(s => s.== id).ToList();            
            var tt = new JavaScriptSerializer().Serialize(joinTables);
            //string json = JsonConvert.SerializeObject(joinTables, Formatting.Indented);
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

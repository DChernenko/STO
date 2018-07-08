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


        public ActionResult Add(BusViewModel bus)
        {
            bool state = ModelState.IsValid;
            
            return View();
        }
        


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}


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
using STO.Domain.Interfaces;
using STO.WebUI.Service;

namespace STO.WebUI.Controllers
{
    [Culture]
    public class CarController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CarController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Add(CarViewModel car)
        {
            var service = new Service<CarViewModel, Car>(_unitOfWork);
            service.Save(car);
            
            return View();
        }        
    }
}


namespace STO.WebUI.Controllers
{
    using STO.Domain.Entities;
    using STO.Domain.Helper;
    using STO.Domain.Interfaces;
    using STO.WebUI.Models;
    using STO.WebUI.Service;
    using System;
    using System.Web.Mvc;

    public class BusController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BusController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Add(BusViewModel bus)
        {
            if (ModelState.IsValid)
            {
                bus.TypeCar = new Service<TypeCarViewModel, TypeCar>(_unitOfWork).Get(STOConst.TypeCar.Bus);
                var service = new Service<BusViewModel, Bus>(_unitOfWork);
                service.Save(bus);
            }
            else {
             
            }
            return RedirectToAction("ShowResult", "Home");
        }
    }
}
namespace STO.WebUI.Controllers
{
    using STO.Domain.Entities;
    using STO.Domain.Helper;
    using STO.Domain.Interfaces;
    using STO.WebUI.Models;
    using STO.WebUI.Service;
    using System;
    using System.Web.Mvc;
    public class TruckController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TruckController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Add(TruckViewModel truck)
        {
            if (ModelState.IsValid)
            {
                truck.TypeCar = new Service<TypeCarViewModel, TypeCar>(_unitOfWork).Get(STOConst.TypeCar.Truck);                
                var service = new Service<TruckViewModel, Truck>(_unitOfWork);
                service.Save(truck);
            }
            else
            {

            }
            return RedirectToAction("ShowResult", "Home");
        }
    }
}
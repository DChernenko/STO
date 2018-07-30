namespace STO.WebUI.Controllers
{
    using STO.Domain.Entities;
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
                //truck.TypeCar = new TypeCar() { Id = new Guid("9235ead9-7893-e811-97a8-00505697018a") };
                var service = new Service<TruckViewModel, Truck>(_unitOfWork);
                service.Save(truck);
            }
            return View();
        }
    }
}
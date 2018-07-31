namespace STO.WebUI.Controllers
{
    using STO.Domain.Entities;
    using STO.Domain.Interfaces;
    using STO.WebUI.Filters;
    using STO.WebUI.Models;
    using STO.WebUI.Service;
    using System;
    using System.Web.Mvc;


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
            if (ModelState.IsValid)
            {
                //car.TypeCar = new TypeCar() { Id = new Guid("9035ead9-7893-e811-97a8-00505697018a") };
                var service = new Service<CarViewModel, Car>(_unitOfWork);
                service.Save(car);
            }
            return View();
        }
    }
}


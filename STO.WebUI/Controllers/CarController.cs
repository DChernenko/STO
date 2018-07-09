namespace STO.WebUI.Controllers
{
    using STO.Domain.Entities;
    using STO.Domain.Interfaces;
    using STO.WebUI.Filters;
    using STO.WebUI.Models;
    using STO.WebUI.Service;
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
            var service = new Service<CarViewModel, Car>(_unitOfWork);
            service.Save(car);
            
            return View();
        }        
    }
}


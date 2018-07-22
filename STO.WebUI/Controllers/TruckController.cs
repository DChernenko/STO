namespace STO.WebUI.Controllers
{
    using STO.Domain.Entities;
    using STO.Domain.Interfaces;
    using STO.WebUI.Models;
    using STO.WebUI.Service;
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
            var service = new Service<TruckViewModel, Truck>(_unitOfWork);
            service.Save(truck);
            return View();
        }
    }
}
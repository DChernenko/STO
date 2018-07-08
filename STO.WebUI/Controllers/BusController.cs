namespace STO.WebUI.Controllers
{
    using STO.Domain.Entities;
    using STO.Domain.Interfaces;
    using STO.WebUI.Models;
    using STO.WebUI.Service;
    using System.Web.Mvc;

    public class BusController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BusController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Add(BusViewModel bus) {
            var service = new Service<BusViewModel, Bus>(_unitOfWork);
            service.Save(bus);
            return View();
        }      
    }
}
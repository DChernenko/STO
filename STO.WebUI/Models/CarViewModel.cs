namespace STO.WebUI.Models
{
    using AutoMapper;
    using STO.Domain.Entities;
    using STO.WebUI.Service;
    using System.ComponentModel.DataAnnotations;

    public class CarViewModel : BaseCarViewModel, IViewModel<CarViewModel, Car>, IModel
    {
        [Display(Name = "Extra", ResourceType = typeof(Resources.View.DetailsRes))]
        public bool Extra { get; set; }
        [Display(Name = "WheelBalancing", ResourceType = typeof(Resources.View.DetailsRes))]
        public int? WheelBalancing { get; set; } = 100;

        public CarViewModel()
        {        }

        public Car ToDBObject()
        {
            //Mapper.Initialize(cfg => cfg.CreateMap<CarViewModel, Car>().ForMember("WheelBalancing", opt => opt.MapFrom(c => c.Undercarriage)));
            throw new System.NotImplementedException();
        }

        public CarViewModel ToViewObject(Car t)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Car, CarViewModel>());
            CarViewModel car = Mapper.Map<Car,CarViewModel> (t);
            return car;
        }
    }
}
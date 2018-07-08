namespace STO.WebUI.Models
{
    using AutoMapper;
    using STO.Domain.Entities;
    using STO.WebUI.Service;
    using System.ComponentModel.DataAnnotations;

    public class CarViewModel : BaseCarViewModel, IViewModel<Car>, IModel
    {
        [Display(Name = "Extra", ResourceType = typeof(Resources.View.DetailsRes))]
        public bool Extra { get; set; }
        [Display(Name = "WheelBalancing", ResourceType = typeof(Resources.View.DetailsRes))]
        public int? WheelBalancing { get; set; } = 100;

        public Car ToDBObject()
        {
            Car car = Mapper.Map<CarViewModel, Car>(this);
            return car;       
        }       

        public IModel ToViewObject(Car t)
        {
            CarViewModel car = Mapper.Map<Car, CarViewModel>(t);
            return car;
        }
    }
}
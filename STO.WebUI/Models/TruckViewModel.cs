namespace STO.WebUI.Models
{
    using AutoMapper;
    using STO.Domain.Entities;
    using STO.WebUI.Service;
    using System.ComponentModel.DataAnnotations;

    public class TruckViewModel : BaseCarViewModel, IViewModel<Truck>, IModel
    {
        [Required(ErrorMessageResourceName = "ValRequiredFld", ErrorMessageResourceType = typeof(Resources.View.DetailsRes))]
        [Range(0, 100, ErrorMessageResourceName = "ValRang0100Fld", ErrorMessageResourceType = typeof(Resources.View.DetailsRes))]
        [Display(Name = "Hydraulics", ResourceType = typeof(Resources.View.DetailsRes))]
        public int Hydraulics { get; set; }

        public Truck ToDBObject()
        {
            Truck truck = Mapper.Map<TruckViewModel, Truck>(this);
            return truck;
        }

        public IModel ToViewObject(Truck t)
        {
            TruckViewModel truck = Mapper.Map<Truck, TruckViewModel>(t);
            return truck;

        }
    }
}
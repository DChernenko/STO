namespace STO.WebUI.Models
{
    using AutoMapper;
    using STO.Domain.Entities;
    using STO.WebUI.Service;
    using System.ComponentModel.DataAnnotations;

    public class BusViewModel : BaseCarViewModel, IViewModel<Bus>, IModel
    {
        [Required(ErrorMessageResourceName = "ValRequiredFld", ErrorMessageResourceType = typeof(Resources.View.DetailsRes))]
        [Range(0, 100, ErrorMessageResourceName = "ValRang0100Fld", ErrorMessageResourceType = typeof(Resources.View.DetailsRes))]
        [Display(Name = "Handrail", ResourceType = typeof(Resources.View.DetailsRes))]
        public int Handrail { get; set; }

        [Required(ErrorMessageResourceName = "ValRequiredFld", ErrorMessageResourceType = typeof(Resources.View.DetailsRes))]
        [Range(0, 100, ErrorMessageResourceName = "ValRang0100Fld", ErrorMessageResourceType = typeof(Resources.View.DetailsRes))]
        [Display(Name = "Seat", ResourceType = typeof(Resources.View.DetailsRes))]
        public int Seat { get; set; }

        [Display(Name = "Extra", ResourceType = typeof(Resources.View.DetailsRes))]
        public bool Extra { get; set; }
        [Display(Name = "SkinReplacement", ResourceType = typeof(Resources.View.DetailsRes))]
        public int SkinReplacement { get; set; } = 300;

        public Bus ToDBObject()
        {
            Bus bus = Mapper.Map<BusViewModel,Bus>(this);
            return bus;
        }

        public IModel ToViewObject(Bus t)
        {
            BusViewModel bus = Mapper.Map<Bus, BusViewModel>(t);
            return bus;
        }
    }
}
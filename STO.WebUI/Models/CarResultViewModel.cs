namespace STO.WebUI.Models
{
    using AutoMapper;
    using STO.Domain.Entities;
    using STO.WebUI.Service;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CarResultViewModel : IViewModel<CarResult>, IModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessageResourceName = "ValRequiredFld", ErrorMessageResourceType = typeof(Resources.View.DetailsRes))]
        [StringLength(8, MinimumLength = 8, ErrorMessageResourceName = "ValStrLengthFld", ErrorMessageResourceType = typeof(Resources.View.DetailsRes))]
        [Display(Name = "CarNumber", ResourceType = typeof(Resources.View.DetailsRes))]
        public string CarNumber { get; set; }


        [Required(ErrorMessageResourceName = "ValRequiredFld", ErrorMessageResourceType = typeof(Resources.View.DetailsRes))]
        [Range(0, 100, ErrorMessageResourceName = "ValRang0100Fld", ErrorMessageResourceType = typeof(Resources.View.DetailsRes))]
        [Display(Name = "CarCase", ResourceType = typeof(Resources.View.DetailsRes))]
        public int CarCase { get; set; }
        public int CarCaseVal { get; set; }

        [Required(ErrorMessageResourceName = "ValRequiredFld", ErrorMessageResourceType = typeof(Resources.View.DetailsRes))]
        [Range(0, 100, ErrorMessageResourceName = "ValRang0100Fld", ErrorMessageResourceType = typeof(Resources.View.DetailsRes))]
        [Display(Name = "Wheel", ResourceType = typeof(Resources.View.DetailsRes))]
        public int Wheel { get; set; }
        public int WheelVal { get; set; }

        [Required(ErrorMessageResourceName = "ValRequiredFld", ErrorMessageResourceType = typeof(Resources.View.DetailsRes))]
        [Range(0, 100, ErrorMessageResourceName = "ValRang0100Fld", ErrorMessageResourceType = typeof(Resources.View.DetailsRes))]
        [Display(Name = "Engine", ResourceType = typeof(Resources.View.DetailsRes))]
        public int Engine { get; set; }
        public int EngineVal { get; set; }

        [Required(ErrorMessageResourceName = "ValRequiredFld", ErrorMessageResourceType = typeof(Resources.View.DetailsRes))]
        [Range(0, 100, ErrorMessageResourceName = "ValRang0100Fld", ErrorMessageResourceType = typeof(Resources.View.DetailsRes))]
        [Display(Name = "Brake", ResourceType = typeof(Resources.View.DetailsRes))]
        public int Brake { get; set; }
        public int BrakeVal { get; set; }

        [Required(ErrorMessageResourceName = "ValRequiredFld", ErrorMessageResourceType = typeof(Resources.View.DetailsRes))]
        [Range(0, 100, ErrorMessageResourceName = "ValRang0100Fld", ErrorMessageResourceType = typeof(Resources.View.DetailsRes))]
        [Display(Name = "Undercarriage", ResourceType = typeof(Resources.View.DetailsRes))]
        public int Undercarriage { get; set; }
        public int UndercarriageVal { get; set; }

        public int? AddService { get; set; }
        //public int? WheelBalancing { get; set; }

        [Required(ErrorMessageResourceName = "ValRequiredFld", ErrorMessageResourceType = typeof(Resources.View.DetailsRes))]
        [Range(0, 100, ErrorMessageResourceName = "ValRang0100Fld", ErrorMessageResourceType = typeof(Resources.View.DetailsRes))]
        [Display(Name = "Handrail", ResourceType = typeof(Resources.View.DetailsRes))]
        public int? Handrail { get; set; }
        public int? HandrailVal { get; set; }

        [Required(ErrorMessageResourceName = "ValRequiredFld", ErrorMessageResourceType = typeof(Resources.View.DetailsRes))]
        [Range(0, 100, ErrorMessageResourceName = "ValRang0100Fld", ErrorMessageResourceType = typeof(Resources.View.DetailsRes))]
        [Display(Name = "Seat", ResourceType = typeof(Resources.View.DetailsRes))]
        public int? Seat { get; set; }
        public int? SeatVal { get; set; }

        //public int? SkinReplacement { get; set; }

        [Required(ErrorMessageResourceName = "ValRequiredFld", ErrorMessageResourceType = typeof(Resources.View.DetailsRes))]
        [Range(0, 100, ErrorMessageResourceName = "ValRang0100Fld", ErrorMessageResourceType = typeof(Resources.View.DetailsRes))]
        [Display(Name = "Hydraulics", ResourceType = typeof(Resources.View.DetailsRes))]
        public int? Hydraulics { get; set; }
        public int? HydraulicsVal { get; set; }


        public int TotalPrice { get; set; }

        public int AvgState { get; set; }

        //public string TypeCar { get; set; }



        public CarResult ToDBObject()
        {
            CarResult carResult = Mapper.Map<CarResultViewModel, CarResult>(this);
            return carResult;
        }

        public IModel ToViewObject(CarResult t)
        {
            CarResultViewModel carResult = Mapper.Map<CarResult, CarResultViewModel>(t);
            return carResult;
        }
    }
}
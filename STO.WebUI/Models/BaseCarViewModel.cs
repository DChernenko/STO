namespace STO.WebUI.Models
{
    using STO.Domain.Entities;
    using STO.WebUI.Service;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public interface IModel { }

    public abstract class BaseCarViewModel : IViewModel<BaseCar>, IModel
    {
        public Guid? Id { set; get; }

        //[Required(ErrorMessageResourceName = "ValRequiredFld", ErrorMessageResourceType = typeof(Resources.View.DetailsRes))]        
        //[Display(Name = "TypeCar", ResourceType = typeof(Resources.View.DetailsRes))]
        public TypeCar TypeCar { get; set; }

        [Required(ErrorMessageResourceName = "ValRequiredFld", ErrorMessageResourceType = typeof(Resources.View.DetailsRes))]
        [StringLength(8, MinimumLength = 8, ErrorMessageResourceName = "ValStrLengthFld", ErrorMessageResourceType = typeof(Resources.View.DetailsRes))]
        [Display(Name = "CarNumber", ResourceType = typeof(Resources.View.DetailsRes))]
        public string CarNumber { get; set; }

        [Required(ErrorMessageResourceName = "ValRequiredFld", ErrorMessageResourceType = typeof(Resources.View.DetailsRes))]
        [Range(0, 100, ErrorMessageResourceName = "ValRang0100Fld", ErrorMessageResourceType = typeof(Resources.View.DetailsRes))]
        [Display(Name = "CarCase", ResourceType = typeof(Resources.View.DetailsRes))]
        public int CarCase { get; set; }

        [Required(ErrorMessageResourceName = "ValRequiredFld", ErrorMessageResourceType = typeof(Resources.View.DetailsRes))]
        [Range(0, 100, ErrorMessageResourceName = "ValRang0100Fld", ErrorMessageResourceType = typeof(Resources.View.DetailsRes))]
        [Display(Name = "Wheel", ResourceType = typeof(Resources.View.DetailsRes))]
        public int Wheel { get; set; }

        [Required(ErrorMessageResourceName = "ValRequiredFld", ErrorMessageResourceType = typeof(Resources.View.DetailsRes))]
        [Range(0, 100, ErrorMessageResourceName = "ValRang0100Fld", ErrorMessageResourceType = typeof(Resources.View.DetailsRes))]
        [Display(Name = "Engine", ResourceType = typeof(Resources.View.DetailsRes))]
        public int Engine { get; set; }

        [Required(ErrorMessageResourceName = "ValRequiredFld", ErrorMessageResourceType = typeof(Resources.View.DetailsRes))]
        [Range(0, 100, ErrorMessageResourceName = "ValRang0100Fld", ErrorMessageResourceType = typeof(Resources.View.DetailsRes))]
        [Display(Name = "Brake", ResourceType = typeof(Resources.View.DetailsRes))]
        public int Brake { get; set; }


        [Required(ErrorMessageResourceName = "ValRequiredFld", ErrorMessageResourceType = typeof(Resources.View.DetailsRes))]
        [Range(0, 100, ErrorMessageResourceName = "ValRang0100Fld", ErrorMessageResourceType = typeof(Resources.View.DetailsRes))]
        [Display(Name = "Undercarriage", ResourceType = typeof(Resources.View.DetailsRes))]
        public int Undercarriage { get; set; }

        [HiddenInput(DisplayValue = false)]
        [Display(Name = "CreatedDate", ResourceType = typeof(Resources.View.DetailsRes))]
        public DateTime CreatedDate { get; set; } = DateTime.Now;


        public BaseCar ToDBObject()
        {
            throw new NotImplementedException();
        }

        public IModel ToViewObject(BaseCar t)
        {
            throw new NotImplementedException();
        }
    }
}
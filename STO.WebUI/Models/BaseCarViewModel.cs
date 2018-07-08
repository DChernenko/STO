namespace STO.WebUI.Models
{
    using System.ComponentModel.DataAnnotations;
    public interface IModel { }
    public abstract class BaseCarViewModel
    {
        [Required(ErrorMessageResourceName = "ValRequiredFld", ErrorMessageResourceType = typeof(Resources.View.DetailsRes))]
        [MaxLength(8, ErrorMessageResourceName = "ValStrLengthFld", ErrorMessageResourceType = typeof(Resources.View.DetailsRes))]
        [MinLength(8, ErrorMessageResourceName = "ValStrLengthFld", ErrorMessageResourceType = typeof(Resources.View.DetailsRes))]
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
    }
}
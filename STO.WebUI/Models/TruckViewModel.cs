namespace STO.WebUI.Models
{
    using System.ComponentModel.DataAnnotations;

    public class TruckViewModel : BaseCarViewModel
    {
        [Required(ErrorMessageResourceName = "ValRequiredFld", ErrorMessageResourceType = typeof(Resources.View.DetailsRes))]
        [Range(0, 100, ErrorMessageResourceName = "ValRang0100Fld", ErrorMessageResourceType = typeof(Resources.View.DetailsRes))]
        [Display(Name = "Hydraulics", ResourceType = typeof(Resources.View.DetailsRes))]
        public int Hydraulics { get; set; }
    }
}
namespace STO.WebUI.Models
{
    using System.ComponentModel.DataAnnotations;

    public class BusViewModel : BaseCarViewModel
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
    }
}
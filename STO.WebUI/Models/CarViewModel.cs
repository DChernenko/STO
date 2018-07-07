namespace STO.WebUI.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CarViewModel:BaseCarViewModel
    {
        [Display(Name = "Extra", ResourceType = typeof(Resources.View.DetailsRes))]
        public bool Extra { get; set; }
        [Display(Name = "WheelBalancing", ResourceType = typeof(Resources.View.DetailsRes))]
        public int WheelBalancing { get; set; } = 100;
    }
}
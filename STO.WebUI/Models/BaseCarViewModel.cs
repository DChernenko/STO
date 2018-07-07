namespace STO.WebUI.Models
{
    using System.ComponentModel.DataAnnotations;

    public abstract class BaseCarViewModel
    {
        [Required(ErrorMessage = "Поле обов'язково для заповнення")]
        [Range(0, 100, ErrorMessage = "Значення повино бути в межах від 0 до 100")]
        public int CarCase { get; set; }

        [Required(ErrorMessage = "Поле обов'язково для заповнення")]
        [Range(0, 100, ErrorMessage = "Значення повино бути в межах від 0 до 100")]
        public int Wheel { get; set; }

        [Required(ErrorMessage = "Поле обов'язково для заповнення")]
        [Range(0, 100, ErrorMessage = "Значення повино бути в межах від 0 до 100")]
        public int Engine { get; set; }

        [Required(ErrorMessage = "Поле обов'язково для заповнення")]
        [Range(0, 100, ErrorMessage = "Значення повино бути в межах від 0 до 100")]
        public int Brake { get; set; }

        [Required(ErrorMessage = "Поле обов'язково для заповнення")]
        [Range(0, 100, ErrorMessage = "Значення повино бути в межах від 0 до 100")]
        public int Undercarriage { get; set; }
    }
}
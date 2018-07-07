using System.ComponentModel.DataAnnotations;

namespace STO.WebUI.Models
{
    public class BusViewModel : BaseCarViewModel
    {
        public int Handrail { get; set; }
        public int Seat { get; set; }
        public bool Extra { get; set; }
        public int SkinReplacement { get; set; } = 300;
    }
}
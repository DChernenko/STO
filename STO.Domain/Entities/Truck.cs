using System.ComponentModel.DataAnnotations.Schema;

namespace STO.Domain.Entities
{
    public class Truck : BaseCar
    {
        public int Hydraulics { get; set; }
    }
}

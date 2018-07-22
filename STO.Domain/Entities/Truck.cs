using System.ComponentModel.DataAnnotations.Schema;

namespace STO.Domain.Entities
{
    //[Table("BaseCar")]
    public class Truck : BaseCar
    {
        public int Hydraulics { get; set; }
    }
}

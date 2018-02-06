using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STO.Domain.Entities
{
    [Serializable]
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Number { get; set; }

        public int? TypeCarId { get; set; }
        public TypeCar TypeCar { get; set; }

        public ICollection<CalculateCost> CalculateCostes { get; set; }
        public ICollection<TotalPrice> TotalPrices { get; set; }

        public Car()
        {
            CalculateCostes = new List<CalculateCost>();
            TotalPrices = new List<TotalPrice>();
        }

    }
}

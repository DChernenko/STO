using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STO.Domain.Entities
{
    
    public class TotalPrice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public decimal Total { get; set; }
        public DateTime Date { get; set; }
        public double AvgState { get; set; }
        public int? CarId { get; set; }
        public Car Car { get; set; }

        public virtual List<CalculateCost> CalculateCost { get; set; }

        public TotalPrice()
        {
            CalculateCost = new List<CalculateCost>();
        }


    }
}

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
    public class TotalPrice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public decimal Total { get; set; }
        public DateTime Date { get; set; }

        //public ICollection<Car> Cars { get; set; }

        public int? CarId { get; set; }
        public Car Car { get; set; }

        public TotalPrice()
        {
            //Cars = new List<Car>();


        }

    }
}

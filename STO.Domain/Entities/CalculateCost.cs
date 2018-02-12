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
    public class CalculateCost
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int State { get; set; }

        public int? CarId { get; set; }
        public Car Car { get; set; }

        public int? TypeServiceId { get; set; }
        public TypeService TypeService { get; set; }

        public int? TotalPriceId { get; set; }
        public TotalPrice TotalPrice { get; set; }


        public CalculateCost()
        { }
    }
}

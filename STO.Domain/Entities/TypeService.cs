using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace STO.Domain.Entities
{
    public class TypeService
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? ServiceId { get; set; }
        public virtual Service Service { get; set; }
        public int? TypeCarId { get; set; }
        public virtual TypeCar TypeCar { get; set; }
        public virtual ICollection<CalculateCost> CalculateCostes { get; set; }

        public TypeService()
        {
            CalculateCostes = new List<CalculateCost>();
        }
    }
}

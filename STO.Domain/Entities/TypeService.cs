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
    [Serializable]
    [DataContract]
    public class TypeService
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int? ServiceId { get; set; }
        [DataMember]
        public Service Service { get; set; }

        [DataMember]
        public int? TypeCarId { get; set; }
        [DataMember]
        public TypeCar TypeCar { get; set; }

        //public int? CalculateCostId { get; set; }
        //public CalculateCost CalculateCost { get; set; }
        [DataMember]
        public ICollection<CalculateCost> CalculateCostes { get; set; }


        public TypeService()
        {
            CalculateCostes = new List<CalculateCost>();
        }



    }
}

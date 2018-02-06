using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace STO.Domain.Entities
{
    [Serializable]
    [DataContract]
    public class TypeCar
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public String Name { get; set; }

        [DataMember]
        public ICollection<TypeService> TypeServices { get; set; }


        public TypeCar()
        {
            TypeServices = new List<TypeService>();
        }
    }
}

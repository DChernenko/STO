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
    public class Service
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public String Name { get; set; }
        [DataMember]
        public bool IsAddService { get; set; }
        [DataMember]
        public decimal Cost { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
        [DataMember]
        public ICollection<TypeService> TypeServices { get; set; }

        public Service()
        {
            TypeServices = new List<TypeService>();
        }
    }
}

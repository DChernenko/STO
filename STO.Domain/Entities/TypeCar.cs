using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace STO.Domain.Entities
{
    public class TypeCar
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string UrlForm { get; set; }

        public virtual ICollection<TypeService> TypeServices { get; set; }

        public TypeCar()
        {
            TypeServices = new List<TypeService>();
        }
    }
}

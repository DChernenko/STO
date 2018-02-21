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
    public class Service
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public String Name { get; set; }

        public bool IsAddService { get; set; }

        public decimal Cost { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<TypeService> TypeServices { get; set; }

        public Service()
        {
            TypeServices = new List<TypeService>();
        }
    }
}

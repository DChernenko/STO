namespace STO.Domain.Entities
{
    using STO.Domain.Interfaces;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class TypeCar : IEntity
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]      
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UrlForm { get; set; }


        public virtual BaseCar BaseCar { get; set; }

        //public virtual ICollection<TypeService> TypeServices { get; set; }
        //public TypeCar()
        //{
        //    TypeServices = new List<TypeService>();
        //}
    }
}

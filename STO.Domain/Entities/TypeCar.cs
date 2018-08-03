namespace STO.Domain.Entities
{
    using STO.Domain.Interfaces;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class TypeCar : IEntity
    {
        [Key]        
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UrlForm { get; set; }
    }
}

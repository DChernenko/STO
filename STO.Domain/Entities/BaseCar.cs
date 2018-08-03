namespace STO.Domain.Entities
{
    using System;
    using STO.Domain.Interfaces;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    public class BaseCar : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public Guid Id { get; set; }
        public string CarNumber { get; set; }
        public int CarCase { get; set; }
        public int Wheel { get; set; }
        public int Engine { get; set; }
        public int Brake { get; set; }
        public int Undercarriage { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedDate { get; set; }

        //[ForeignKey("Id")]
        //[Required]
        public Guid TypeCarId { get; set; }
        public virtual TypeCar TypeCar { get; set; }

    }
}

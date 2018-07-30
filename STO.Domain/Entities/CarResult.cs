﻿namespace STO.Domain.Entities
{
    using System;
    using STO.Domain.Interfaces;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("VCalculateResult")]
    public class CarResult : IEntity
    {
        public Guid Id { get; set; }
        public string CarNumber { get; set; }
        public int CarCase { get; set; }
        public int CarCaseVal { get; set; }
        public int Wheel { get; set; }
        public int WheelVal { get; set; }
        public int Engine { get; set; }
        public int EngineVal { get; set; }
        public int Brake { get; set; }
        public int BrakeVal { get; set; }
        public int Undercarriage { get; set; }
        public int UndercarriageVal { get; set; }
        public int? WheelBalancing { get; set; }
        public int Handrail { get; set; }
        public int HandrailVal { get; set; }
        public int Seat { get; set; }
        public int SeatVal { get; set; }
        public int? SkinReplacement { get; set; }
        public int Hydraulics { get; set; }
        public int HydraulicsVal { get; set; }
        public int TotalPrice { get; set; }

        public int AvgState { get; set; }

        public string TypeCar { get; set; }
    }
}

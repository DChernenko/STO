using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STO.WebUI.Models
{
    public class CarInfo
    {
        public string Number { get; set; }
        public decimal Total { get; set; }
        public int TypeCar { get; set; }
        public DateTime Date { get; set; }
        public double AvgState { get; set; }
        public List<CarServiceInfo> Services { get; set; }
    }
    public class CarServiceInfo
    {
        public int State { get; set; }
        public bool IsAddService { get; set; }
        public string ServiceName { get; set; }
        public decimal Cost { get; set; }
    }
}
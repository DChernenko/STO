using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STO.WebUI.Models
{
    public class AddDataAdapter
    {
        public int TypeCarId { get; set; }
        public Dictionary<int, int> Services { get; set; }
        public string NumberCar { get; set; }
    }
}
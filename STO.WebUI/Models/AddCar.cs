using STO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STO.WebUI.Models
{
    public class AddCar
    {
        public TypeCar TypeCar { get; set; }
        public List<Service> Services { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace STO.BLL.DTO
{
    public class TypeServiceDTO
    {
        public int Id { get; set; }

        public int? ServicesId { get; set; }
        public ServiceDTO Service { get; set; }


        public int? TypeCarId { get; set; }
        public TypeCarDTO TypeCar { get; set; }
    }
}

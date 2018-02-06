using System;
using System.Collections.Generic;
using System.Text;

namespace STO.BLL.DTO
{
   public  class CalculateCostDTO
    {
        public int Id { get; set; }
        public int State { get; set; }

        public ICollection<CarDTO> Cars { get; set; }
        public ICollection<TypeServiceDTO> TypeServices { get; set; }

        public CalculateCostDTO()
        {
            Cars = new List<CarDTO>();
            TypeServices = new List<TypeServiceDTO>();
        }
    }
}

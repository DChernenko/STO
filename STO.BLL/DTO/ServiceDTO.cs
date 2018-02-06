using System;
using System.Collections.Generic;
using System.Text;

namespace STO.BLL.DTO
{
    public class ServiceDTO
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public bool IsAddService { get; set; }
        public decimal Cost { get; set; }

        public bool IsActive { get; set; }
        public ICollection<TypeServiceDTO> TypeServices { get; set; }
        public ServiceDTO()
        {
            TypeServices = new List<TypeServiceDTO>();
        }
    }
}

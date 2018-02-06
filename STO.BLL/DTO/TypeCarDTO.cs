using System;
using System.Collections.Generic;
using System.Text;

namespace STO.BLL.DTO
{
    public class TypeCarDTO
    {
        public int Id { get; set; }
        public String Name { get; set; }

        public ICollection<TypeServiceDTO> TypeServices { get; set; }

        public TypeCarDTO()
        {
            TypeServices = new List<TypeServiceDTO>();
        }
    }
}

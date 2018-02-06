using System;
using System.Collections.Generic;
using System.Text;

namespace STO.BLL.DTO
{
    public class TotalPriceDTO
    {
        public int Id { get; set; }
        public decimal Total { get; set; }
        public DateTime Date { get; set; }

        public ICollection<CarDTO> Cars { get; set; }
        public TotalPriceDTO()
        {
            Cars = new List<CarDTO>();
        }
    }
}

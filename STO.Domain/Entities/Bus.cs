using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STO.Domain.Entities
{
    public class Bus: BaseCar
    {
        public int Handrail { get; set; }
        public int Seat { get; set; }
        public int? SkinReplacement { get; set; }
    }
}

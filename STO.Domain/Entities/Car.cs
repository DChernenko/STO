using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STO.Domain.Entities
{
    public class Car: BaseCar
    {
        public int? WheelBalancing { get; set; }
    }
}

using STO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STO.Domain.Concrete
{
    public class VCalculateResultConfiguration : EntityTypeConfiguration<CarResult>
    {
        public VCalculateResultConfiguration()
        {           
            this.ToTable("VCalculateResult");
        }
    }
}

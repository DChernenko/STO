using STO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STO.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        //public EFDbContext() : base("EFDbContext") { }
        public DbSet<CalculateCost> CalculateCostes { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<TotalPrice> TotalPrices { get; set; }
        public DbSet<TypeCar> TypeCars { get; set; }
        public DbSet<TypeService> TypeServices { get; set; }
        public DbSet<Car> Cars { get;  set; }

        public EFDbContext(string connectionString)
           : base(connectionString)
        {
        }
        static EFDbContext()
        {
            Database.SetInitializer<EFDbContext>(new ContextInit());
        }
    }
}

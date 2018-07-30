
namespace STO.Domain.Concrete
{
    using STO.Domain.Entities;
    using System.Data.Entity;

    public class EFDbContext : DbContext
    {
        //public DbSet<CalculateCost> CalculateCostes { get; set; }
        //public DbSet<Service> Services { get; set; }
        //public DbSet<TotalPrice> TotalPrices { get; set; }
        //public DbSet<Car> Cars { get; set; }
        //public DbSet<Bus> Buses { get; set; }
        //public DbSet<Truck> Trucks { get; set; }

        public DbSet<TypeCar> TypeCars { get; set; }
        public DbSet<TypeService> TypeServices { get; set; }
        public DbSet<BaseCar> BaseCar { get; set; }
        public DbSet<CarResult> CarResult { get; set; }

        public EFDbContext(string connectionString)
           : base(connectionString)
        {
        }
        public EFDbContext()
            : base("EFDbContext")
        {
        }
        static EFDbContext()
        {
            Database.SetInitializer<EFDbContext>(new ContextInit());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<BaseCar>();
            //modelBuilder.Entity<Car>().Map(
            //    m =>
            //    {
            //        m.MapInheritedProperties();
            //        //m.ToTable("Cars");
            //    }
            //    );

            //modelBuilder.Entity<Bus>().Map(
            //    m =>
            //    {
            //        m.MapInheritedProperties();
            //        //m.ToTable("Buses");
            //    }
            //    );

            //modelBuilder.Entity<Truck>().Map(
            //    m =>
            //    {
            //        m.MapInheritedProperties();
            //        //m.ToTable("Trucks");
            //    }
            //    );

        }
    }
}

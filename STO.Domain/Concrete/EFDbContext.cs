namespace STO.Domain.Concrete
{
    using STO.Domain.Entities;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class EFDbContext : DbContext
    {
        //public DbSet<CalculateCost> CalculateCostes { get; set; }
        //public DbSet<Service> Services { get; set; }
        //public DbSet<TotalPrice> TotalPrices { get; set; }
        //public DbSet<Car> Cars { get; set; }
        //public DbSet<Bus> Buses { get; set; }
        //public DbSet<Truck> Trucks { get; set; }

        public DbSet<TypeCar> TypeCars { get; set; }
        //public DbSet<TypeService> TypeServices { get; set; }
        public DbSet<BaseCar> BaseCars { get; set; }
        public DbSet<CarResult> CarResults { get; set; }

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
            

            modelBuilder.Configurations.Add(new VCalculateResultConfiguration());
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<CarResult>().HasKey(t => t.Id);
            //modelBuilder.Entity<CarResult>() Query<CarResult>().ToView("VCalculateResult");                       
        }
    }
}

namespace STO.Domain.Concrete
{
    using STO.Domain.Entities;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class EFDbContext : DbContext
    {
        public DbSet<TypeCar> TypeCars { get; set; }
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
            base.OnModelCreating(modelBuilder);
        }
    }
}

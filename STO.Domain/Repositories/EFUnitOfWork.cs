using STO.Domain.Concrete;
using STO.Domain.Entities;
using STO.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STO.Domain.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private EFDbContext db;
        private bool disposed = false;
        private CalculateCostRepository calculateCostRepository;
        private ServiceRepository serviceRepository;
        private TotalPriceRepository totalPriceRepository;
        private CarRepository carRepository;
        private TypeServiceRepository typeServiceRepository;
        private TypeCarRepository typeCarRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new EFDbContext(connectionString);
        }
        public IRepository<CalculateCost> CalculateCostes
        {
            get
            {
                if (calculateCostRepository == null)
                    calculateCostRepository = new CalculateCostRepository(db);
                return calculateCostRepository;
            }
        }

        public IRepository<Service> Services
        {
            get
            {
                if (serviceRepository == null)
                    serviceRepository = new ServiceRepository(db);
                return serviceRepository;
            }
        }

        public IRepository<TotalPrice> TotalPrices
        {
            get
            {
                if (totalPriceRepository == null)
                    totalPriceRepository = new TotalPriceRepository(db);
                return totalPriceRepository;
            }
        }

        public IRepository<TypeCar> TypeCars
        {
            get
            {
                if (typeCarRepository == null)
                    typeCarRepository = new TypeCarRepository(db);
                return typeCarRepository;
            }
        }

        public IRepository<TypeService> TypeServices
        {
            get
            {
                if (typeServiceRepository == null)
                    typeServiceRepository = new TypeServiceRepository(db);
                return typeServiceRepository;
            }
        }

        public IRepository<Car> Cars
        {
            get
            {
                if (carRepository == null)
                    carRepository = new CarRepository(db);
                return carRepository;
            }
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}

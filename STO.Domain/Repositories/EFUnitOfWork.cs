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
        private EFDbContext _db;
        private bool _disposed = false;
        private CalculateCostRepository _calculateCostRepository;
        private ServiceRepository _serviceRepository;
        private TotalPriceRepository _totalPriceRepository;
        private CarRepository _carRepository;
        private TypeServiceRepository _typeServiceRepository;
        private TypeCarRepository _typeCarRepository;

        public EFUnitOfWork(string connectionString)
        {
            _db = new EFDbContext(connectionString);
        }
        public EFUnitOfWork()
        {

        }

        public IRepository<CalculateCost> CalculateCostes
        {
            get
            {
                if (_calculateCostRepository == null)
                    _calculateCostRepository = new CalculateCostRepository(_db);
                return _calculateCostRepository;
            }
        }

        public IRepository<Service> Services
        {
            get
            {
                if (_serviceRepository == null)
                    _serviceRepository = new ServiceRepository(_db);
                return _serviceRepository;
            }
        }

        public IRepository<TotalPrice> TotalPrices
        {
            get
            {
                if (_totalPriceRepository == null)
                    _totalPriceRepository = new TotalPriceRepository(_db);
                return _totalPriceRepository;
            }
        }

        public IRepository<TypeCar> TypeCars
        {
            get
            {
                if (_typeCarRepository == null)
                    _typeCarRepository = new TypeCarRepository(_db);
                return _typeCarRepository;
            }
        }

        public IRepository<TypeService> TypeServices
        {
            get
            {
                if (_typeServiceRepository == null)
                    _typeServiceRepository = new TypeServiceRepository(_db);
                return _typeServiceRepository;
            }
        }

        public IRepository<Car> Cars
        {
            get
            {
                if (_carRepository == null)
                    _carRepository = new CarRepository(_db);
                return _carRepository;
            }
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                this._disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}

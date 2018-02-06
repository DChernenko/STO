using STO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STO.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<CalculateCost> CalculateCostes { get; }
        IRepository<Service> Services { get; }
        IRepository<TotalPrice> TotalPrices { get; }
        IRepository<TypeCar> TypeCars { get; }
        IRepository<TypeService> TypeServices { get; }
        IRepository<Car> Cars { get; }
                
        void Save();
    }
}

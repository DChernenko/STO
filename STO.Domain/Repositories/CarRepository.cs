using STO.Domain.Concrete;
using STO.Domain.Entities;
using STO.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace STO.Domain.Repositories
{
   public class CarRepository : IRepository<Car>
    {
        private EFDbContext _db;
        public CarRepository(EFDbContext db)
        {
            this._db = db;
        }

        public void Create(Car item)
        {
            _db.Cars.Add(item);
        }

        public void Delete(int id)
        {
            //Car b = new Car { Id = id };
            //db.Entry(b).State = EntityState.Deleted;
            Car c = _db.Cars.Find(id);
            if (c != null)
                _db.Cars.Remove(c);
        }

        public IEnumerable<Car> Find(Func<Car, bool> predicate)
        {
            return _db.Cars.Where(predicate).ToList();
        }

        public Car Get(int id)
        {
            return _db.Cars.Find(id);
        }

        public IEnumerable<Car> GetAll()
        {
            return _db.Cars;
        }

        public void Update(Car item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }
    }
}

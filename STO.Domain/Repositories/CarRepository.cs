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
        private EFDbContext db;
        public CarRepository(EFDbContext db)
        {
            this.db = db;
        }

        public void Create(Car item)
        {
            db.Cars.Add(item);
        }

        public void Delete(int id)
        {
            //Car b = new Car { Id = id };
            //db.Entry(b).State = EntityState.Deleted;
            Car c = db.Cars.Find(id);
            if (c != null)
                db.Cars.Remove(c);
        }

        public IEnumerable<Car> Find(Func<Car, bool> predicate)
        {
            return db.Cars.Where(predicate).ToList();
        }

        public Car Get(int id)
        {
            return db.Cars.Find(id);
        }

        public IEnumerable<Car> GetAll()
        {
            return db.Cars;
        }

        public void Update(Car item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}

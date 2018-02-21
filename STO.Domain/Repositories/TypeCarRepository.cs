using STO.Domain.Concrete;
using STO.Domain.Entities;
using STO.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace STO.Domain.Repositories
{
    public class TypeCarRepository : IRepository<TypeCar>
    {
        private EFDbContext _db;
        public TypeCarRepository(EFDbContext db)
        {
            this._db = db;
        }

        public void Create(TypeCar item)
        {
            _db.TypeCars.Add(item);
        }

        public void Delete(int id)
        {
            //TypeCar b = new TypeCar { Id = id };
            //db.Entry(b).State = EntityState.Deleted;
            TypeCar c = _db.TypeCars.Find(id);
            if (c != null)
                _db.TypeCars.Remove(c);
        }

        public IEnumerable<TypeCar> Find(Func<TypeCar, bool> predicate)
        {
            return _db.TypeCars.Where(predicate).ToList();
        }

        public TypeCar Get(int id)
        {
            return _db.TypeCars.Find(id);
        }

        public IEnumerable<TypeCar> GetAll()
        {
            return _db.TypeCars;
        }

        public void Update(TypeCar item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }
    }
}

using STO.Domain.Concrete;
using STO.Domain.Entities;
using STO.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace STO.Domain.Repositories
{
    public class TotalPriceRepository : IRepository<TotalPrice>
    {
        private EFDbContext _db;
        public TotalPriceRepository(EFDbContext db)
        {
            this._db = db;
        }

        public void Create(TotalPrice item)
        {
            _db.TotalPrices.Add(item);
        }

        public void Delete(int id)
        {
            //TotalPrice b = new TotalPrice { Id = id };
            //db.Entry(b).State = EntityState.Deleted;
            TotalPrice c = _db.TotalPrices.Find(id);
            if (c != null)
                _db.TotalPrices.Remove(c);
        }

        public IEnumerable<TotalPrice> Find(Func<TotalPrice, bool> predicate)
        {
            return _db.TotalPrices.Where(predicate).ToList();
        }

        public TotalPrice Get(int id)
        {
            return _db.TotalPrices.Find(id);
        }

        public IEnumerable<TotalPrice> GetAll()
        {
            return _db.TotalPrices;
        }

        public void Update(TotalPrice item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }
    }
}

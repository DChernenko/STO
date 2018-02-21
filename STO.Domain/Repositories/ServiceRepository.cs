using STO.Domain.Concrete;
using STO.Domain.Entities;
using STO.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace STO.Domain.Repositories
{
    public class ServiceRepository : IRepository<Service>
    {
        private EFDbContext _db;
        public ServiceRepository(EFDbContext db)
        {
            this._db = db;
        }

        public void Create(Service item)
        {
            _db.Services.Add(item);
        }

        public void Delete(int id)
        {
            //Service b = new Service { Id = id };
            //db.Entry(b).State = EntityState.Deleted;
            Service c = _db.Services.Find(id);
            if (c != null)
                _db.Services.Remove(c);
        }

        public IEnumerable<Service> Find(Func<Service, bool> predicate)
        {
            return _db.Services.Where(predicate).ToList();
        }

        public Service Get(int id)
        {
            return _db.Services.Find(id);
        }

        public IEnumerable<Service> GetAll()
        {
            return _db.Services;
        }

        public void Update(Service item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }
    }
}

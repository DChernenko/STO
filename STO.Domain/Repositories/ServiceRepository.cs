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
        private EFDbContext db;
        public ServiceRepository(EFDbContext db)
        {
            this.db = db;
        }

        public void Create(Service item)
        {
            db.Services.Add(item);
        }

        public void Delete(int id)
        {
            //Service b = new Service { Id = id };
            //db.Entry(b).State = EntityState.Deleted;
            Service c = db.Services.Find(id);
            if (c != null)
                db.Services.Remove(c);
        }

        public IEnumerable<Service> Find(Func<Service, bool> predicate)
        {
            return db.Services.Where(predicate).ToList();
        }

        public Service Get(int id)
        {
            return db.Services.Find(id);
        }

        public IEnumerable<Service> GetAll()
        {
            return db.Services;
        }

        public void Update(Service item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}

using STO.Domain.Concrete;
using STO.Domain.Entities;
using STO.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STO.Domain.Repositories
{
    public class TypeServiceRepository : IRepository<TypeService>
    {
        private EFDbContext db;
        public TypeServiceRepository(EFDbContext db)
        {
            this.db = db;
        }

        public void Create(TypeService item)
        {
            db.TypeServices.Add(item);
        }

        public void Delete(int id)
        {
            //TypeService b = new TypeService { Id = id };
            //db.Entry(b).State = EntityState.Deleted;
            TypeService c = db.TypeServices.Find(id);
            if (c != null)
                db.TypeServices.Remove(c);
        }

        public IEnumerable<TypeService> Find(Func<TypeService, bool> predicate)
        {
            return db.TypeServices.Where(predicate).ToList();
        }

        public TypeService Get(int id)
        {
            return db.TypeServices.Find(id);
        }

        public IEnumerable<TypeService> GetAll()
        {
            return db.TypeServices;
        }

        public void Update(TypeService item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}

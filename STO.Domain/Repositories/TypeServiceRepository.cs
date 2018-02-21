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
        private EFDbContext _db;
        public TypeServiceRepository(EFDbContext db)
        {
            this._db = db;
        }

        public void Create(TypeService item)
        {
            _db.TypeServices.Add(item);
        }

        public void Delete(int id)
        {
            //TypeService b = new TypeService { Id = id };
            //db.Entry(b).State = EntityState.Deleted;
            TypeService c = _db.TypeServices.Find(id);
            if (c != null)
                _db.TypeServices.Remove(c);
        }

        public IEnumerable<TypeService> Find(Func<TypeService, bool> predicate)
        {
            return _db.TypeServices.Where(predicate).ToList();
        }

        public TypeService Get(int id)
        {
            return _db.TypeServices.Find(id);
        }

        public IEnumerable<TypeService> GetAll()
        {
            return _db.TypeServices;
        }

        public void Update(TypeService item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }
    }
}

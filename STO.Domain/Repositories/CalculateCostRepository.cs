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
    public class CalculateCostRepository : IRepository<CalculateCost>
    {
        private EFDbContext db;
        public CalculateCostRepository(EFDbContext db)
        {
            this.db = db;
        }

        public void Create(CalculateCost item)
        {
            db.CalculateCostes.Add(item);
        }

        public void Delete(int id)
        {
            //CalculateCost b = new CalculateCost { Id = id };
            //db.Entry(b).State = EntityState.Deleted;
            CalculateCost c = db.CalculateCostes.Find(id);
            if (c != null)
                db.CalculateCostes.Remove(c);
        }

        public IEnumerable<CalculateCost> Find(Func<CalculateCost, bool> predicate)
        {
            return db.CalculateCostes.Where(predicate).ToList();
        }

        public CalculateCost Get(int id)
        {
            return db.CalculateCostes.Find(id);
        }

        public IEnumerable<CalculateCost> GetAll()
        {
            return db.CalculateCostes;
        }

        public void Update(CalculateCost item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}

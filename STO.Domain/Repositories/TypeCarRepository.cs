﻿using STO.Domain.Concrete;
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
        private EFDbContext db;
        public TypeCarRepository(EFDbContext db)
        {
            this.db = db;
        }

        public void Create(TypeCar item)
        {
            db.TypeCars.Add(item);
        }

        public void Delete(int id)
        {
            //TypeCar b = new TypeCar { Id = id };
            //db.Entry(b).State = EntityState.Deleted;
            TypeCar c = db.TypeCars.Find(id);
            if (c != null)
                db.TypeCars.Remove(c);
        }

        public IEnumerable<TypeCar> Find(Func<TypeCar, bool> predicate)
        {
            return db.TypeCars.Where(predicate).ToList();
        }

        public TypeCar Get(int id)
        {
            return db.TypeCars.Find(id);
        }

        public IEnumerable<TypeCar> GetAll()
        {
            return db.TypeCars;
        }

        public void Update(TypeCar item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
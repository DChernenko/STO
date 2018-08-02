﻿namespace STO.Domain.Repositories
{
    using STO.Domain.Interfaces;
    using System.Data.Entity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        protected readonly DbContext _dataContext;
        protected readonly DbSet<T> _dataSet;

        public Repository(DbContext dataContext)
        {
            _dataContext = dataContext;
            _dataSet = dataContext.Set<T>();
        }

        public IQueryable<T> Query()
        {
            return _dataSet;
        }

        public IEnumerable<T> All()
        {
            return _dataSet.ToList();
        }

        public async Task<IEnumerable<T>> AllAsync()
        {
            return await _dataSet.ToListAsync();
        }

        public T Get(Guid id)
        {
            return _dataSet.FirstOrDefault(x => x.Id == id);
        }

        public async Task<T> GetAsync(Guid id)
        {
            return await _dataSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public T Find(Func<T, bool> predicate)
        {
            return _dataSet.FirstOrDefault(predicate);
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dataSet.FirstOrDefaultAsync(predicate);
        }

        public void Add(T entity)
        {
            _dataSet.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _dataSet.AddRange(entities);
        }

        public void Attach(T entity)
        {
            _dataContext.Entry(entity).State = EntityState.Modified;
        }
        public bool Update(T entity)
        {
            var item = Find(t => t.Id == entity.Id);
            if (item == null)
            {
                return false;
            }

            _dataContext.Entry(item).CurrentValues.SetValues(entity);
            return true;
        }

        public void Delete(T entity)
        {
            _dataSet.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _dataSet.RemoveRange(entities);
        }

        public void Save()
        {
            //_dataContext.Entry().
            _dataContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _dataContext.SaveChangesAsync();
        }
        public void Dispose()
        {
            _dataContext.Dispose();
        }
    }
}

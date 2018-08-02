using STO.Domain.Interfaces;
using STO.WebUI.Models;
using System;
using System.Collections.Generic;

namespace STO.WebUI.Service
{
    public interface IService<T, E> where T : IViewModel<E>
                                   where E : class, IEntity

    {
        void Save(List<T> list);
        void Save(T item);
        IEnumerable<T> GetLists();
        IEnumerable<T> GetLists(int skipt, int take);
        T Get(Guid id);
    }
}

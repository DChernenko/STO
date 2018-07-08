using STO.Domain.Interfaces;
using STO.WebUI.Models;
using System.Collections.Generic;

namespace STO.WebUI.Service
{
    public interface IService<T, E> where T : IViewModel<IModel, E>
                                   where E : class, IEntity

    {
        void Save(List<T> list);
        IEnumerable<T> GetLists();
    }
}

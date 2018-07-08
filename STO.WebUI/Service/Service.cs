using STO.Domain.Interfaces;
using STO.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace STO.WebUI.Service
{
    public class Service<T, E> : IService<T, E>
                                     where T : IViewModel<IModel, E>
                                   where E : class, IEntity
    {
        private readonly IUnitOfWork _unitOfWork;
        public Service(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<T> GetLists()
        {

            return _unitOfWork.Repository<E>().All().Select(s=> { var temp = Activator.CreateInstance<T>();
                return (T)temp.ToViewObject(s);
            });
        }

        public void Save(List<T> list)
        {
            //throw new NotImplementedException();
        }
    }
}
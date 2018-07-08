using STO.Domain.Interfaces;
using STO.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace STO.WebUI.Service
{
    public class Service<T, E> : IService<T, E>
                                     where T : IViewModel<E>
                                   where E : class, IEntity
    {
        private readonly IUnitOfWork _unitOfWork;

        public Service(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<T> GetLists()
        {

            return _unitOfWork.Repository<E>().All().Select(s =>
            {
                var temp = Activator.CreateInstance<T>();
                return (T)temp.ToViewObject(s);
            }).ToList();
        }

        public void Save(List<T> list)
        {
            foreach (var item in list)
            {
                if (_unitOfWork.Repository<E>().Find(t => t.Id == item.ToDBObject().Id) != null) {
                    _unitOfWork.Repository<E>().Update(item.ToDBObject());
                }
                else
                {
                    _unitOfWork.Repository<E>().Add(item.ToDBObject().);
                }
            }
            _unitOfWork.Save();
        }
    }
}
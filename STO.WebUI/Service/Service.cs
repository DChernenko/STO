namespace STO.WebUI.Service
{
    using AutoMapper;
    using STO.Domain.Interfaces;
    using System.Collections.Generic;
    using System.Linq;

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
            return _unitOfWork.Repository<E>().All().Select(s => Mapper.Map<E, T>(s)).ToList();
        }

        public IEnumerable<T> GetLists(int skipt, int take)
        {
            return _unitOfWork.Repository<E>()
                .Query()
                .OrderByDescending(o => o.Id)
                .Skip(skipt)
                .Take(take)
                .ToList()
                .Select(s => Mapper.Map<E, T>(s));
        }

        public void Save(List<T> list)
        {
            foreach (var item in list)
            {
                if (_unitOfWork.Repository<E>().Find(t => t.Id == item.ToDBObject().Id) != null)
                {
                    _unitOfWork.Repository<E>().Update(item.ToDBObject());
                }
                else
                {
                    _unitOfWork.Repository<E>().Add(item.ToDBObject());
                }
            }
            _unitOfWork.Save();
        }

        public void Save(T item)
        {
            if (_unitOfWork.Repository<E>().Find(t => t.Id == item.ToDBObject().Id) != null)
            {
                _unitOfWork.Repository<E>().Update(item.ToDBObject());
            }
            else
            {
                _unitOfWork.Repository<E>().Add(item.ToDBObject());
            }
            _unitOfWork.Save();
        }
    }
}
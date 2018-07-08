namespace STO.WebUI.Service
{
    using STO.Domain.Interfaces;

    public interface IViewModel<E ,T> where T : IEntity
                                        where E : class
    {
        T ToDBObject();
        E ToViewObject(T t);
    }
}

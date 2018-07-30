namespace STO.WebUI.Service
{
    using STO.Domain.Interfaces;
    using STO.WebUI.Models;

    public interface IViewModel<E> where E : IEntity
                                        
    {
        E ToDBObject();
        IModel ToViewObject(E t);
    }
}

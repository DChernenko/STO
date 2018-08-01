namespace STO.WebUI.Service
{
    using STO.Domain.Interfaces;

    public interface IViewModel<E> where E : IEntity
    {
        E ToDBObject();
    }
}

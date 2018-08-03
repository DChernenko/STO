namespace STO.WebUI.Models
{
    using AutoMapper;
    using STO.Domain.Entities;
    using STO.WebUI.Service;
    using System;

    public class TypeCarViewModel : IViewModel<TypeCar>, IModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UrlForm { get; set; }
                
        public BaseCarViewModel BaseCar { get; set; }

        public TypeCar ToDBObject()
        {
            return Mapper.Map<TypeCarViewModel, TypeCar>(this);
        }

        public IModel ToViewObject(TypeCar t)
        {
            return Mapper.Map<TypeCar, TypeCarViewModel>(t);
        }
    }
}
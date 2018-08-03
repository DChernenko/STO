namespace STO.WebUI.MappingSettings
{
    using AutoMapper;
    using STO.Domain.Entities;
    using STO.WebUI.Models;

    public class CarProfile : Profile
    {
        protected override void Configure()
        {

            Mapper.CreateMap<Car, CarViewModel>()
                .ForMember(c => c.Extra, x => x.MapFrom(s => s.WheelBalancing != null))
                .ForMember(c => c.TypeCar, x => x.MapFrom(s => s.TypeCar))
                .ForMember(c => c.TypeCar, opt => opt.Ignore());

            Mapper.CreateMap<CarViewModel, Car>()
                .ForMember(c => c.WheelBalancing, x => x.MapFrom(s => s.Extra ? s.WheelBalancing : 0))
                .ForMember(c => c.TypeCarId, x => x.MapFrom(s => s.TypeCar.Id))
                .ForMember(c => c.TypeCar, opt => opt.Ignore());
        }
    }

    public class BusProfile : Profile
    {
        protected override void Configure()
        {


            Mapper.CreateMap<Bus, BusViewModel>()
               .ForMember(c => c.Extra, x => x.MapFrom(s => s.SkinReplacement != null))
               .ForMember(c => c.TypeCar, x => x.MapFrom(s => s.TypeCar))
                .ForMember(c => c.TypeCar, opt => opt.Ignore());

            Mapper.CreateMap<BusViewModel, Bus>()
               .ForMember(c => c.SkinReplacement, x => x.MapFrom(s => s.Extra ? s.SkinReplacement : 0))
               .ForMember(c => c.TypeCarId, x => x.MapFrom(s => s.TypeCar.Id))
                .ForMember(c => c.TypeCar, opt => opt.Ignore());

        }
    }

    public class TruckProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Truck, TruckViewModel>()
                .ForMember(c => c.TypeCar, x => x.MapFrom(s => s.TypeCar))
                .ForMember(c => c.TypeCar, opt => opt.Ignore());

            Mapper.CreateMap<TruckViewModel, Truck>()
                .ForMember(c => c.TypeCarId, x => x.MapFrom(s => s.TypeCar.Id))
                .ForMember(c => c.TypeCar, opt => opt.Ignore());

        }
    }

    public class TypeCarProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<TypeCar, TypeCarViewModel>();

            Mapper.CreateMap<TypeCarViewModel, TypeCar>();
        }
    }

    public class CarResultProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<CarResult, CarResultViewModel>();

            Mapper.CreateMap<CarResultViewModel, CarResult>();
        }
    }
}
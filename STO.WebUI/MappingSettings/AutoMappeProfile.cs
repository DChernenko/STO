namespace STO.WebUI.MappingSettings
{

    using AutoMapper;
    using STO.Domain.Entities;
    using STO.WebUI.Models;


    public class CarToVMProfile : Profile
    {
        protected override void Configure()
        {

            Mapper.CreateMap<Car, CarViewModel>().ForMember(c => c.Extra, x => x.MapFrom(s => s.WheelBalancing != null));
        }
    }
    public class VMToCarProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<CarViewModel, Car>().ForMember(c => c.WheelBalancing, x => x.MapFrom(s => s.Extra ? s.WheelBalancing : 0));
        }
    }

    public class VMToBusProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<BusViewModel, Bus>().ForMember(c => c.SkinReplacement, x => x.MapFrom(s => s.Extra ? s.SkinReplacement : 0)); ;
        }
    }

    public class BusToVMProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Bus, BusViewModel>().ForMember(c => c.Extra, x => x.MapFrom(s => s.SkinReplacement != null));
        }
    }

    public class VMToTruckProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<TruckViewModel, Truck>();
        }
    }

    public class TruckToVMProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Truck, TruckViewModel>();
        }
    }


    public class TypeCarToVMProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<TypeCar, TypeCarViewModel>();
        }
    }
    public class VMToTypeCarProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<TypeCarViewModel, TypeCar>();
        }
    }



}
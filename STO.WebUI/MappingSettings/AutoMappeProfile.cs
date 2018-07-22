using AutoMapper;
using AutoMapper.Mappers;
using STO.Domain.Entities;
using STO.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STO.WebUI.MappingSettings
{
    public class CarToVMProfile: Profile
    {
        protected override void Configure()
        {
            AutoMapper.Mapper.CreateMap<Car, CarViewModel>();
        }
    }
    public class VMToCarProfile : Profile
    {
        protected override void Configure()
        {
            AutoMapper.Mapper.CreateMap<CarViewModel,Car>();
        }
    }

    public class VMToBusProfile : Profile
    {
        protected override void Configure()
        {
            AutoMapper.Mapper.CreateMap<BusViewModel, Bus>();
        }
    }

    public class BusToVMProfile : Profile
    {
        protected override void Configure()
        {
            AutoMapper.Mapper.CreateMap<Bus, BusViewModel>();
        }
    }

    public class VMToTruckProfile : Profile
    {
        protected override void Configure()
        {
            AutoMapper.Mapper.CreateMap<TruckViewModel, Truck>();
        }
    }

    public class TruckToVMProfile : Profile
    {
        protected override void Configure()
        {
            AutoMapper.Mapper.CreateMap<Truck, TruckViewModel>();
        }
    }


    public class TypeCarToVMProfile : Profile
    {
        protected override void Configure()
        {
            AutoMapper.Mapper.CreateMap<TypeCar, TypeCarViewModel>();
        }
    }
    public class VMToTypeCarProfile : Profile
    {
        protected override void Configure()
        {
            AutoMapper.Mapper.CreateMap<TypeCarViewModel, TypeCar>();
        }
    }



}
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STO.WebUI.MappingSettings
{
    public class MapperInit
    {
        public static void Init() {
            Mapper.Initialize(x =>
            {
                x.AddProfile<CarToVMProfile>();
                x.AddProfile<VMToCarProfile>();
                x.AddProfile<BusToVMProfile>();
                x.AddProfile<VMToBusProfile>();
                x.AddProfile<TruckToVMProfile>();
                x.AddProfile<VMToTruckProfile>();
            });
        }
    }
}
namespace STO.WebUI.MappingSettings
{
    using AutoMapper;

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
                x.AddProfile<TypeCarToVMProfile>();
                x.AddProfile<VMToTypeCarProfile>();
                x.AddProfile<CarResultToVMProfile>();
                x.AddProfile<VMToCarResultProfile>();
            });
        }
    }
}
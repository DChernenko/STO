namespace STO.WebUI.MappingSettings
{
    using AutoMapper;

    public class MapperInit
    {
        public static void Init() {
            Mapper.Initialize(x =>
            {
                x.AddProfile<CarProfile>();
                x.AddProfile<BusProfile>();
                x.AddProfile<TruckProfile>();
                x.AddProfile<TypeCarProfile>();
                x.AddProfile<CarResultProfile>();
            });
        }
    }
}
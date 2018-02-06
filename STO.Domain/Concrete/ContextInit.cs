using STO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STO.Domain.Concrete
{
    public class ContextInit : DropCreateDatabaseAlways<EFDbContext>
    {
        protected override void Seed(EFDbContext db)
        {
            TypeCar t1 = new TypeCar { Id = 1, Name = "Легковой автомобиль" };
            TypeCar t2 = new TypeCar { Id = 2, Name = "Автобус" };
            TypeCar t3 = new TypeCar { Id = 3, Name = "Грузовик" };
            db.TypeCars.AddRange(new List<TypeCar>() { t1, t2, t3 });
            /*
            db.TypeCars.Add(t1);
            db.TypeCars.Add(t2);
            db.TypeCars.Add(t3);
            */
            Service s1 = new Service { Id = 1, Name = "Кузов", IsAddService = false, IsActive = true };
            Service s2 = new Service { Id = 2, Name = "Колеса", IsAddService = false, IsActive = true };
            Service s3 = new Service { Id = 3, Name = "Двигатель", IsAddService = false, IsActive = true };
            Service s4 = new Service { Id = 4, Name = "Тормоза", IsAddService = false, IsActive = true };
            Service s5 = new Service { Id = 5, Name = "Ходовая", IsAddService = false, IsActive = true };
            Service s6 = new Service { Id = 6, Name = "Гидравлика", IsAddService = false, IsActive = true };
            Service s7 = new Service { Id = 7, Name = "Салон", IsAddService = false, IsActive = true };
            Service s8 = new Service { Id = 8, Name = "Поручни", IsAddService = false, IsActive = true };
            Service s9 = new Service { Id = 9, Name = "Балансировка колес", IsAddService = true, Cost = 100, IsActive = true };
            Service s10 = new Service { Id = 10, Name = "Обивка сидений", IsAddService = true, Cost = 300, IsActive = true };

            db.Services.AddRange(new List<Service>() { s1, s2, s3, s4, s5, s6, s7, s8, s9, s10 });
            /*
            db.Services.Add(s1);
            db.Services.Add(s2);
            db.Services.Add(s3);
            db.Services.Add(s4);
            db.Services.Add(s5);
            db.Services.Add(s6);
            db.Services.Add(s7);
            db.Services.Add(s8);
            db.Services.Add(s9);
            db.Services.Add(s10);
            */

            TypeService ts1 = new TypeService { Id = 1, TypeCarId = 1, ServiceId = 1 };
            TypeService ts2 = new TypeService { Id = 2, TypeCarId = 1, ServiceId = 2 };
            TypeService ts3 = new TypeService { Id = 3, TypeCarId = 1, ServiceId = 3 };
            TypeService ts4 = new TypeService { Id = 4, TypeCarId = 1, ServiceId = 4 };
            TypeService ts5 = new TypeService { Id = 5, TypeCarId = 1, ServiceId = 5 };
            TypeService ts6 = new TypeService { Id = 6, TypeCarId = 1, ServiceId = 9 };
            TypeService ts7 = new TypeService { Id = 7, TypeCarId = 2, ServiceId = 1 };
            TypeService ts8 = new TypeService { Id = 8, TypeCarId = 2, ServiceId = 2 };
            TypeService ts9 = new TypeService { Id = 9, TypeCarId = 2, ServiceId = 3 };
            TypeService ts10 = new TypeService { Id = 10, TypeCarId = 2, ServiceId = 4 };
            TypeService ts11 = new TypeService { Id = 11, TypeCarId = 2, ServiceId = 5 };
            TypeService ts12 = new TypeService { Id = 12, TypeCarId = 2, ServiceId = 7 };
            TypeService ts13 = new TypeService { Id = 13, TypeCarId = 2, ServiceId = 8 };
            TypeService ts14 = new TypeService { Id = 14, TypeCarId = 2, ServiceId = 10 };
            TypeService ts15 = new TypeService { Id = 15, TypeCarId = 3, ServiceId = 1 };
            TypeService ts16 = new TypeService { Id = 16, TypeCarId = 3, ServiceId = 2 };
            TypeService ts17 = new TypeService { Id = 17, TypeCarId = 3, ServiceId = 3 };
            TypeService ts18 = new TypeService { Id = 18, TypeCarId = 3, ServiceId = 4 };
            TypeService ts19 = new TypeService { Id = 19, TypeCarId = 3, ServiceId = 5 };
            TypeService ts20 = new TypeService { Id = 20, TypeCarId = 3, ServiceId = 6 };

            db.TypeServices.AddRange(new List<TypeService>()
            {
             ts1,   ts2,    ts3,    ts4,    ts5,    ts6,    ts7,   ts8,    ts9,    ts10,
             ts11,   ts12,   ts13,   ts14,   ts15,   ts16,   ts17,  ts18,   ts19,   ts20
            });

        }
    }
}

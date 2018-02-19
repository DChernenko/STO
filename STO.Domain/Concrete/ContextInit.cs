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
            // test data for list cars
            AddTypeCar(db);
            AddService(db);
            AddTypeService(db);
            AddCar(db);
            AddTotalCost(db);
            AddCalculateCostes(db);
        }
        private void AddTypeCar(EFDbContext db)
        {
            TypeCar t1 = new TypeCar { Id = 1, Name = "Легковой автомобиль" };
            TypeCar t2 = new TypeCar { Id = 2, Name = "Автобус" };
            TypeCar t3 = new TypeCar { Id = 3, Name = "Грузовик" };
            db.TypeCars.AddRange(new List<TypeCar>() { t1, t2, t3 });

        }
        private void AddService(EFDbContext db)
        {
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
        }
        private void AddTypeService(EFDbContext db)
        {
            #region TypeCar1       
            TypeService ts1 = new TypeService { Id = 1, TypeCarId = 1, ServiceId = 1 };
            TypeService ts2 = new TypeService { Id = 2, TypeCarId = 1, ServiceId = 2 };
            TypeService ts3 = new TypeService { Id = 3, TypeCarId = 1, ServiceId = 3 };
            TypeService ts4 = new TypeService { Id = 4, TypeCarId = 1, ServiceId = 4 };
            TypeService ts5 = new TypeService { Id = 5, TypeCarId = 1, ServiceId = 5 };
            TypeService ts6 = new TypeService { Id = 6, TypeCarId = 1, ServiceId = 9 };
            db.TypeServices.AddRange(new List<TypeService>() { ts1, ts2, ts3, ts4, ts5, ts6 });
            #endregion
            #region TypeCar2       
            TypeService ts7 = new TypeService { Id = 7, TypeCarId = 2, ServiceId = 1 };
            TypeService ts8 = new TypeService { Id = 8, TypeCarId = 2, ServiceId = 2 };
            TypeService ts9 = new TypeService { Id = 9, TypeCarId = 2, ServiceId = 3 };
            TypeService ts10 = new TypeService { Id = 10, TypeCarId = 2, ServiceId = 4 };
            TypeService ts11 = new TypeService { Id = 11, TypeCarId = 2, ServiceId = 5 };
            TypeService ts12 = new TypeService { Id = 12, TypeCarId = 2, ServiceId = 7 };
            TypeService ts13 = new TypeService { Id = 13, TypeCarId = 2, ServiceId = 8 };
            TypeService ts14 = new TypeService { Id = 14, TypeCarId = 2, ServiceId = 10 };
            db.TypeServices.AddRange(new List<TypeService>() { ts7, ts8, ts9, ts10, ts11, ts12, ts13, ts14 });
            #endregion
            #region TypeCar3       
            TypeService ts15 = new TypeService { Id = 15, TypeCarId = 3, ServiceId = 1 };
            TypeService ts16 = new TypeService { Id = 16, TypeCarId = 3, ServiceId = 2 };
            TypeService ts17 = new TypeService { Id = 17, TypeCarId = 3, ServiceId = 3 };
            TypeService ts18 = new TypeService { Id = 18, TypeCarId = 3, ServiceId = 4 };
            TypeService ts19 = new TypeService { Id = 19, TypeCarId = 3, ServiceId = 5 };
            TypeService ts20 = new TypeService { Id = 20, TypeCarId = 3, ServiceId = 6 };
            db.TypeServices.AddRange(new List<TypeService>() { ts15, ts16, ts17, ts18, ts19, ts20 });
            #endregion            
        }
        private void AddCar(EFDbContext db)
        {
            #region TypeCar1  
            Car car1 = new Car() { Id = 1, Number = "AA1111AA", TypeCarId = 1 };
            Car car2 = new Car() { Id = 2, Number = "BB1111BB", TypeCarId = 1 };
            Car car3 = new Car() { Id = 3, Number = "CC1111CC", TypeCarId = 1 };
            db.Cars.AddRange(new List<Car>() { car1, car2, car3 });
            #endregion
            #region TypeCar1 
            Car car4 = new Car() { Id = 4, Number = "AA2222AA", TypeCarId = 2 };
            Car car5 = new Car() { Id = 5, Number = "BB2222BB", TypeCarId = 2 };
            Car car6 = new Car() { Id = 6, Number = "CC2222CC", TypeCarId = 2 };
            db.Cars.AddRange(new List<Car>() { car4, car5, car6 });
            #endregion
            #region TypeCar1 
            Car car7 = new Car() { Id = 7, Number = "AA3333AA", TypeCarId = 3 };
            Car car8 = new Car() { Id = 8, Number = "BB3333BB", TypeCarId = 3 };
            Car car9 = new Car() { Id = 9, Number = "CC3333CC", TypeCarId = 3 };
            db.Cars.AddRange(new List<Car>() { car7, car8, car9 });
            #endregion            
        }
        private void AddCalculateCostes(EFDbContext db)
        {
            #region Car1                     
            CalculateCost с1 = new CalculateCost() { Id = 1, CarId = 1, State = 55, TypeServiceId = 1, TotalPriceId = 1 };
            CalculateCost с2 = new CalculateCost() { Id = 2, CarId = 1, State = 65, TypeServiceId = 2, TotalPriceId = 1 };
            CalculateCost с3 = new CalculateCost() { Id = 3, CarId = 1, State = 54, TypeServiceId = 3, TotalPriceId = 1 };
            CalculateCost с4 = new CalculateCost() { Id = 4, CarId = 1, State = 87, TypeServiceId = 4, TotalPriceId = 1 };
            CalculateCost с5 = new CalculateCost() { Id = 5, CarId = 1, State = 23, TypeServiceId = 5, TotalPriceId = 1 };
            CalculateCost с6 = new CalculateCost() { Id = 6, CarId = 1, State = 12, TypeServiceId = 6, TotalPriceId = 1 };
            db.CalculateCostes.AddRange(new List<CalculateCost>() { с1, с2, с3, с4, с5, с6 });
            #endregion
            #region Car2
            CalculateCost c7 = new CalculateCost() { Id = 7, CarId = 2, State = 25, TypeServiceId = 1, TotalPriceId = 2 };
            CalculateCost c8 = new CalculateCost() { Id = 8, CarId = 2, State = 25, TypeServiceId = 2, TotalPriceId = 2 };
            CalculateCost c9 = new CalculateCost() { Id = 9, CarId = 2, State = 24, TypeServiceId = 3, TotalPriceId = 2 };
            CalculateCost c10 = new CalculateCost() { Id = 10, CarId = 2, State = 27, TypeServiceId = 4, TotalPriceId = 2 };
            CalculateCost c11 = new CalculateCost() { Id = 11, CarId = 2, State = 23, TypeServiceId = 5, TotalPriceId = 2 };
            CalculateCost c12 = new CalculateCost() { Id = 12, CarId = 2, State = 22, TypeServiceId = 6, TotalPriceId = 2 };
            db.CalculateCostes.AddRange(new List<CalculateCost>() { c7, c8, c9, c10, c11, c12 });
            #endregion
            #region Car3
            CalculateCost c13 = new CalculateCost() { Id = 13, CarId = 3, State = 65, TypeServiceId = 1, TotalPriceId = 3 };
            CalculateCost c14 = new CalculateCost() { Id = 14, CarId = 3, State = 65, TypeServiceId = 2, TotalPriceId = 3 };
            CalculateCost c15 = new CalculateCost() { Id = 15, CarId = 3, State = 64, TypeServiceId = 3, TotalPriceId = 3 };
            CalculateCost c16 = new CalculateCost() { Id = 16, CarId = 3, State = 67, TypeServiceId = 4, TotalPriceId = 3 };
            CalculateCost c17 = new CalculateCost() { Id = 17, CarId = 3, State = 63, TypeServiceId = 5, TotalPriceId = 3 };
            CalculateCost c18 = new CalculateCost() { Id = 18, CarId = 3, State = 62, TypeServiceId = 6, TotalPriceId = 3 };
            db.CalculateCostes.AddRange(new List<CalculateCost>() { c13, c14, c15, c16, c17, c18 });
            #endregion

            #region Car4
            CalculateCost c19 = new CalculateCost() { Id = 19, CarId = 4, State = 65, TypeServiceId = 7, TotalPriceId = 4 };
            CalculateCost c20 = new CalculateCost() { Id = 20, CarId = 4, State = 65, TypeServiceId = 8, TotalPriceId = 4 };
            CalculateCost c21 = new CalculateCost() { Id = 21, CarId = 4, State = 64, TypeServiceId = 9, TotalPriceId = 4 };
            CalculateCost c22 = new CalculateCost() { Id = 22, CarId = 4, State = 67, TypeServiceId = 10, TotalPriceId = 4 };
            CalculateCost c23 = new CalculateCost() { Id = 23, CarId = 4, State = 63, TypeServiceId = 11, TotalPriceId = 4 };
            CalculateCost c24 = new CalculateCost() { Id = 24, CarId = 4, State = 62, TypeServiceId = 12, TotalPriceId = 4 };
            CalculateCost c25 = new CalculateCost() { Id = 25, CarId = 4, State = 63, TypeServiceId = 13, TotalPriceId = 4 };
            CalculateCost c26 = new CalculateCost() { Id = 26, CarId = 4, State = 62, TypeServiceId = 14, TotalPriceId = 4 };
            db.CalculateCostes.AddRange(new List<CalculateCost>() { c19, c20, c21, c22, c23, c24, c25, c26 });
            #endregion
            #region Car5
            CalculateCost c27 = new CalculateCost() { Id = 27, CarId = 5, State = 85, TypeServiceId = 7, TotalPriceId = 5 };
            CalculateCost c28 = new CalculateCost() { Id = 28, CarId = 5, State = 85, TypeServiceId = 8, TotalPriceId = 5 };
            CalculateCost c29 = new CalculateCost() { Id = 29, CarId = 5, State = 84, TypeServiceId = 9, TotalPriceId = 5 };
            CalculateCost c31 = new CalculateCost() { Id = 31, CarId = 5, State = 87, TypeServiceId = 10, TotalPriceId = 5 };
            CalculateCost c32 = new CalculateCost() { Id = 32, CarId = 5, State = 83, TypeServiceId = 11, TotalPriceId = 5 };
            CalculateCost c33 = new CalculateCost() { Id = 33, CarId = 5, State = 82, TypeServiceId = 12, TotalPriceId = 5 };
            CalculateCost c34 = new CalculateCost() { Id = 34, CarId = 5, State = 83, TypeServiceId = 13, TotalPriceId = 5 };
            CalculateCost c35 = new CalculateCost() { Id = 35, CarId = 5, State = 82, TypeServiceId = 14, TotalPriceId = 5 };
            db.CalculateCostes.AddRange(new List<CalculateCost>() { c27, c28, c29, c31, c32, c33, c34, c35 });
            #endregion
            #region Car6
            CalculateCost c36 = new CalculateCost() { Id = 36, CarId = 6, State = 25, TypeServiceId = 7, TotalPriceId = 6 };
            CalculateCost c37 = new CalculateCost() { Id = 37, CarId = 6, State = 25, TypeServiceId = 8, TotalPriceId = 6 };
            CalculateCost c38 = new CalculateCost() { Id = 38, CarId = 6, State = 24, TypeServiceId = 9, TotalPriceId = 6 };
            CalculateCost c39 = new CalculateCost() { Id = 39, CarId = 6, State = 27, TypeServiceId = 10, TotalPriceId = 6 };
            CalculateCost c40 = new CalculateCost() { Id = 40, CarId = 6, State = 23, TypeServiceId = 11, TotalPriceId = 6 };
            CalculateCost c41 = new CalculateCost() { Id = 41, CarId = 6, State = 22, TypeServiceId = 12, TotalPriceId = 6 };
            CalculateCost c42 = new CalculateCost() { Id = 42, CarId = 6, State = 23, TypeServiceId = 13, TotalPriceId = 6 };
            CalculateCost c43 = new CalculateCost() { Id = 43, CarId = 6, State = 22, TypeServiceId = 14, TotalPriceId = 6 };
            db.CalculateCostes.AddRange(new List<CalculateCost>() { c36, c37, c38, c39, c40, c41, c42, c43 });
            #endregion

            #region Car7
            CalculateCost c44 = new CalculateCost() { Id = 44, CarId = 7, State = 45, TypeServiceId = 15, TotalPriceId = 7 };
            CalculateCost c45 = new CalculateCost() { Id = 45, CarId = 7, State = 45, TypeServiceId = 16, TotalPriceId = 7 };
            CalculateCost c46 = new CalculateCost() { Id = 46, CarId = 7, State = 44, TypeServiceId = 17, TotalPriceId = 7 };
            CalculateCost c47 = new CalculateCost() { Id = 47, CarId = 7, State = 47, TypeServiceId = 18, TotalPriceId = 7 };
            CalculateCost c48 = new CalculateCost() { Id = 48, CarId = 7, State = 43, TypeServiceId = 19, TotalPriceId = 7 };
            CalculateCost c49 = new CalculateCost() { Id = 49, CarId = 7, State = 42, TypeServiceId = 20, TotalPriceId = 7 };
            db.CalculateCostes.AddRange(new List<CalculateCost>() { c44, c45, c46, c47, c48, c49 });
            #endregion
            #region Car8
            CalculateCost c50 = new CalculateCost() { Id = 50, CarId = 8, State = 95, TypeServiceId = 15, TotalPriceId = 8 };
            CalculateCost c51 = new CalculateCost() { Id = 51, CarId = 8, State = 95, TypeServiceId = 16, TotalPriceId = 8 };
            CalculateCost c52 = new CalculateCost() { Id = 52, CarId = 8, State = 94, TypeServiceId = 17, TotalPriceId = 8 };
            CalculateCost c53 = new CalculateCost() { Id = 53, CarId = 8, State = 97, TypeServiceId = 18, TotalPriceId = 8 };
            CalculateCost c54 = new CalculateCost() { Id = 54, CarId = 8, State = 93, TypeServiceId = 19, TotalPriceId = 8 };
            CalculateCost c55 = new CalculateCost() { Id = 55, CarId = 8, State = 92, TypeServiceId = 20, TotalPriceId = 8 };
            db.CalculateCostes.AddRange(new List<CalculateCost>() { c50, c51, c52, c53, c54, c55 });
            #endregion
            #region Car9
            CalculateCost c56 = new CalculateCost() { Id = 56, CarId = 9, State = 25, TypeServiceId = 15, TotalPriceId = 9 };
            CalculateCost c57 = new CalculateCost() { Id = 57, CarId = 9, State = 25, TypeServiceId = 16, TotalPriceId = 9 };
            CalculateCost c58 = new CalculateCost() { Id = 58, CarId = 9, State = 24, TypeServiceId = 17, TotalPriceId = 9 };
            CalculateCost c59 = new CalculateCost() { Id = 59, CarId = 9, State = 27, TypeServiceId = 18, TotalPriceId = 9 };
            CalculateCost c60 = new CalculateCost() { Id = 60, CarId = 9, State = 23, TypeServiceId = 19, TotalPriceId = 9 };
            CalculateCost c61 = new CalculateCost() { Id = 61, CarId = 9, State = 22, TypeServiceId = 20, TotalPriceId = 9 };
            db.CalculateCostes.AddRange(new List<CalculateCost>() { c56, c57, c58, c59, c60, c61 });
            #endregion
        }
        private void AddTotalCost(EFDbContext db)
        {
            #region Car1-3
            TotalPrice t1 = new TotalPrice() { Id = 1, CarId = 1, Date = new DateTime(2017, 1, 22), AvgState = 33.3 };
            TotalPrice t2 = new TotalPrice() { Id = 2, CarId = 2, Date = new DateTime(2017, 2, 21), AvgState = 13.3 };
            TotalPrice t3 = new TotalPrice() { Id = 3, CarId = 3, Date = new DateTime(2017, 3, 20), AvgState = 23.3 };
            db.TotalPrices.AddRange(new List<TotalPrice>() { t1, t2, t3 });
            #endregion

            #region Car4-6
            TotalPrice t4 = new TotalPrice() { Id = 4, CarId = 4, Date = new DateTime(2017, 4, 29), AvgState = 43.3 };
            TotalPrice t5 = new TotalPrice() { Id = 5, CarId = 5, Date = new DateTime(2017, 5, 12), AvgState = 53.3 };
            TotalPrice t6 = new TotalPrice() { Id = 6, CarId = 6, Date = new DateTime(2017, 6, 15), AvgState = 63.3 };
            db.TotalPrices.AddRange(new List<TotalPrice>() { t4, t5, t6 });
            #endregion

            #region Car7-9
            TotalPrice t7 = new TotalPrice() { Id = 7, CarId = 7, Date = new DateTime(2017, 7, 19), AvgState = 73.3 };
            TotalPrice t8 = new TotalPrice() { Id = 8, CarId = 8, Date = new DateTime(2017, 8, 14), AvgState = 83.3 };
            TotalPrice t9 = new TotalPrice() { Id = 9, CarId = 9, Date = new DateTime(2017, 9, 5), AvgState = 93.3 };
            db.TotalPrices.AddRange(new List<TotalPrice>() { t7, t8, t9 });
            #endregion
        }
    }
}
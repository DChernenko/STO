using STO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STO.Domain.Concrete
{
    public class ContextInit : DropCreateDatabaseAlways<EFDbContext> //DropCreateDatabaseIfModelChanges<EFDbContext> //DropCreateDatabaseAlways<EFDbContext>
    {
        private EFDbContext _db;
        protected override void Seed(EFDbContext db)
        {
            _db = db;
            // test data for list cars
            AddTypeCar();
            AddCar();
            DropViewVCalculateResult();
            CreateViewVCalculateResult();
        }
        private void AddTypeCar()
        {
            TypeCar t1 = new TypeCar { Id = new Guid("61928868-1729-4a8c-918e-77462fa81cdb"), Name = "Легковой автомобиль", UrlForm = "GetCarViewModel" };
            TypeCar t2 = new TypeCar { Id = new Guid("c04b7a59-2ea5-456c-adcb-e21572170e74"), Name = "Автобус", UrlForm = "GetBusViewModel" };
            TypeCar t3 = new TypeCar { Id = new Guid("2e5cffb9-7dc3-43d7-b0ac-ffa52f8cd38f"), Name = "Грузовик", UrlForm = "GetTruckViewModel" };
            _db.TypeCars.AddRange(new List<TypeCar>() { t1, t2, t3 });
        }

        private void AddCar()
        {
            BaseCar bc1 = new Car()
            {
                Brake = 1,
                CarNumber = "11111111",
                Engine = 33,
                Undercarriage = 44,
                Wheel = 55,
                CarCase = 66,
                CreatedDate = DateTime.Now,
                WheelBalancing = 0,
                TypeCarId = new Guid("61928868-1729-4a8c-918e-77462fa81cdb")
            };
            BaseCar bc2 = new Car()
            {
                Brake = 1,
                CarNumber = "11111111",
                Engine = 22,
                Undercarriage = 33,
                Wheel = 44,
                CarCase = 55,
                CreatedDate = DateTime.Now,
                WheelBalancing = 0,
                TypeCarId = new Guid("61928868-1729-4a8c-918e-77462fa81cdb")
            };
            BaseCar bc3 = new Car()
            {
                Brake = 1,
                CarNumber = "11111111",
                Engine = 22,
                Undercarriage = 22,
                Wheel = 33,
                CarCase = 44,
                CreatedDate = DateTime.Now,
                WheelBalancing = 0,
                TypeCarId = new Guid("61928868-1729-4a8c-918e-77462fa81cdb")
            };
            _db.BaseCars.AddRange(new List<BaseCar>() {
                bc1, bc2, bc3
            });
        }
        private void DropViewVCalculateResult()
        {
            _db.Database.ExecuteSqlCommand(@"IF EXISTS (SELECT
                                                  1
                                                FROM INFORMATION_SCHEMA.TABLES
                                                WHERE TABLE_NAME = 'VCalculateResult'
                                                AND TABLE_TYPE = 'BASE TABLE')
                                            BEGIN
                                              DROP TABLE VCalculateResult
                                            END");

            _db.Database.ExecuteSqlCommand(@"IF EXISTS (SELECT
                                                  1
                                                FROM INFORMATION_SCHEMA.TABLES
                                                WHERE TABLE_NAME = 'VCalculateResult'
                                                AND TABLE_TYPE = 'VIEW')
                                            BEGIN
                                              DROP VIEW VCalculateResult
                                            END");
        }

        private void CreateViewVCalculateResult()
        {
            _db.Database.ExecuteSqlCommand(@"CREATE VIEW VCalculateResult
AS
SELECT TOP 100 PERCENT
  t.Id
 ,t.CarNumber
 ,t.Discriminator
 ,t.CarCase
 ,10 * (100 - t.CarCase) AS CarCaseVal
 ,t.Wheel
 ,10 * (100 - t.Wheel) AS WheelVal
 ,t.Engine
 ,10 * (100 - t.Engine) AS EngineVal
 ,t.Brake
 ,10 * (100 - t.Brake) AS BrakeVal
 ,t.Undercarriage
 ,10 * (100 - t.Undercarriage) AS UndercarriageVal
 ,t.CreatedDate AS CreatedDate
 ,t.Handrail
 ,10 * (100 - t.Handrail) AS HandrailVal
 ,t.Seat
 ,10 * (100 - t.Seat) AS SeatVal
 ,t.Hydraulics
 ,10 * (100 - t.Hydraulics) AS HydraulicsVal
 ,t.SkinReplacement
 ,t.WheelBalancing
 ,CASE t.Discriminator
    WHEN 'Bus' THEN t.SkinReplacement
    WHEN 'Car' THEN t.WheelBalancing
    ELSE NULL
  END AS AddService
 ,(10 * (CASE t.Discriminator
    WHEN 'Car' THEN 500
    WHEN 'Truck' THEN 600
    ELSE 700
  END -
  (t.CarCase + t.Wheel + t.Engine + t.Brake + t.Undercarriage + ISNULL(t.Handrail, 0) + ISNULL(t.Seat, 0) + ISNULL(t.Hydraulics, 0))))
  +
  CASE t.Discriminator
    WHEN 'Bus' THEN ISNULL(t.SkinReplacement, 0)
    WHEN 'Car' THEN ISNULL(t.WheelBalancing, 0)
    ELSE 0
  END AS TotalPrice
 ,(T.CarCase + T.Wheel + T.Engine + T.Brake + T.Undercarriage + ISNULL(T.Handrail, 0) + ISNULL(t.Seat, 0) + ISNULL(t.Hydraulics, 0))
  /
  CASE T.Discriminator
    WHEN 'Car' THEN 5
    WHEN 'Truck' THEN 6
    ELSE 7
  END AS AvgState
  ,T.TypeCarId AS TypeCarId
,tc.Name AS TypeCarName
FROM [dbo].[BaseCars] t
  inner JOIN TypeCars tc ON t.TypeCarId = tc.Id
ORDER BY t.CreatedDate DESC;
");

        }
    }
}
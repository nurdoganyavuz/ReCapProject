using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Car car1 = new Car() { BrandId = 5, ColorId = 3, DailyPrice = 560, Description  = "Otomatik", ModelYear = "2018" } ;
            Car car2 = new Car() { BrandId = 5, ColorId = 5, DailyPrice = 760, Description = "Otomatik", ModelYear = "2019" };
            Brand brand = new Brand() { BrandName = "Hyundai" };

            List<Car> cars = new List<Car> {car1, car2 };

            Console.WriteLine("-------------------");

            carManager.Add(cars);
            brandManager.Add(brand);

            Console.WriteLine("-------------------");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id + " numaralı " + car.ModelYear + " model aracın günlük ücreti: " + car.DailyPrice + " TL");
            }

            Console.WriteLine("-------------------");

            foreach (var car in carManager.GetCarsByBrandId(2))
            {
                Console.WriteLine(car.Id + " numaralı araç Renault markasına aittir.");
            }

            Console.WriteLine("-------------------");

            foreach (var car in carManager.GetCarsByColorId(5))
            {
                Console.WriteLine(car.Id + " numaralı araç beyaz renklidir.");
            }

            
            Console.WriteLine("-------------------");

            foreach (var car in carManager.GetByDailyPrice(200,700))
            {
                Console.WriteLine(car.Id + " numaralı aracın fiyatı belirtilen aralıktadır.");
            }
        }
    }
}

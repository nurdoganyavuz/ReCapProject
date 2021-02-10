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
            ColorManager colorManager = new ColorManager(new EfColorDal());

            //TABLOLARA EKLENECEK VERİLER
            Car car1 = new Car() { BrandId = 5, ColorId = 3, CarName = "Cabrio", DailyPrice = 1500, Description  = "Otomatik", ModelYear = "2020" } ;
            Car car2 = new Car() { BrandId = 5, ColorId = 5, CarName = "Tourer", DailyPrice = 960, Description = "Otomatik", ModelYear = "2019" };
            Brand brand = new Brand() { BrandName = "Hyundai" };
            Color color = new Color() { ColorName = "Silver"};

            List<Car> cars = new List<Car> {car1, car2 };
            
            Console.WriteLine("==========CAR CRUD OPERATION TEST==========");

            //carManager.Add(cars); //db'e yeni araba ekleme
            //carManager.Delete(carManager.GetById(20)); //db'den ıd'si verilen arabayı silme

            Console.WriteLine("----------Bütün Arabaları Listeleme----------");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id + " numaralı " + car.ModelYear + " model aracın günlük ücreti: " + car.DailyPrice + " TL");
            }

            Console.WriteLine("----------Aynı Markaya Ait Arabaları Listeleme----------");

            foreach (var car in carManager.GetCarsByBrandId(2))
            {
                Console.WriteLine(car.Id + " numaralı araç Renault markasına aittir.");
            }

            Console.WriteLine("----------Aynı Renge Sahip Arabaları Listeleme----------");

            foreach (var car in carManager.GetCarsByColorId(5))
            {
                Console.WriteLine(car.Id + " numaralı araç beyaz renklidir.");
            }

            Console.WriteLine("----------Verilen Fiyat Aralığındaki Arabaları Listeleme----------");

            foreach (var car in carManager.GetByDailyPrice(200, 700))
            {
                Console.WriteLine(car.Id + " numaralı aracın fiyatı belirtilen aralıktadır.");
            }

            Console.WriteLine("----------Araba Detayları Listeleme (DTO)----------");

            foreach (var carDetail in carManager.GetCarDetails())
            {
                Console.WriteLine("Araba Adı: " + carDetail.CarName +
                                  " / Marka Adı: " + carDetail.BrandName +
                                  " / Renk: " + carDetail.ColorName +
                                  " / Günlük Ücret: " + carDetail.DailyPrice);
            }

            Console.WriteLine("==========BRAND CRUD OPERATION TEST==========");

            //brandManager.Add(brand); //marka ekleme
            //brandManager.Delete(brandManager.GetById(6)); //ıd'si verilen markayı db'den silme

            Console.WriteLine("----------Bütün Markaları Listeleme----------");

            foreach (var brands in brandManager.GetAllBrands())
            {
                Console.WriteLine(brands.BrandId + " : " + brands.BrandName);
            }

            Console.WriteLine("==========COLOR CRUD OPERATION TEST==========");

            //colorManager.Add(color); //renk ekleme
            //colorManager.Delete(colorManager.GetById(7)); //db'den renk silme

            Console.WriteLine("----------Bütün Renkleri Listeleme----------");

            foreach (var colors in colorManager.GetAllColors())
            {
                Console.WriteLine(colors.ColorId + " : " + colors.ColorName);
            }
        }
    }
}
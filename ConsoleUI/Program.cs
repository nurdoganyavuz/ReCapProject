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
            Car car3 = new Car() { BrandId = 2, ColorId = 6, CarName = "Dacia", DailyPrice = 560, Description = "Manuel", ModelYear = "2011" };
            Car car4 = new Car() { BrandId = 4, ColorId = 2, CarName = "GLK", DailyPrice = 1500, Description = "Otomatik", ModelYear = "2019" };
            Brand brand = new Brand() { BrandName = "Hyundai" };
            Color color = new Color() { ColorName = "Silver"};

            
            Console.WriteLine("==========CAR CRUD OPERATION TEST==========");

            //Console.WriteLine("----------Araba Ekleme----------");

            //direkt bu şekilde ekleyebiliriz -> işlem sonucunda mesaj vermesini istemiyorsak.
            //carManager.Add(car4);  

            //ekleyip eklemediğini message olarak göstersin istersek bu şekilde yaparız:
            //var carAdded = carManager.Add(car4); 

            //if (carAdded.Success == true)
            //{
            //    Console.WriteLine(carAdded.Message);
            //}
            //else
            //{
            //    Console.WriteLine(carAdded.Message);
            //}
            

            //carManager.Delete(carManager.GetById(1002).Data); //db'den ıd'si verilen arabayı silme işlemi.

            Console.WriteLine("----------Bütün Arabaları Listeleme----------");

            if (carManager.GetAll().Success == true)
            {
                foreach (var car in carManager.GetAll().Data)
                {
                    Console.WriteLine(car.Id + " numaralı " + car.ModelYear + " model aracın günlük ücreti: " + car.DailyPrice + " TL");
                }
            }
            else
            {
                Console.WriteLine(carManager.GetAll().Message);
            }
            
            Console.WriteLine("----------Aynı Markaya Ait Arabaları Listeleme----------");

            foreach (var car in carManager.GetCarsByBrandId(2).Data)
            {
                Console.WriteLine(car.Id + " numaralı araç Renault markasına aittir.");
            }

            Console.WriteLine("----------Aynı Renge Sahip Arabaları Listeleme----------");

            foreach (var car in carManager.GetCarsByColorId(5).Data)
            {
                Console.WriteLine(car.Id + " numaralı araç beyaz renklidir.");
            }

            Console.WriteLine("----------Verilen Fiyat Aralığındaki Arabaları Listeleme----------");

            foreach (var car in carManager.GetByDailyPrice(200, 700).Data)
            {
                Console.WriteLine(car.Id + " numaralı aracın fiyatı belirtilen aralıktadır.");
            }

            Console.WriteLine("----------Araba Detayları Listeleme (DTO)----------");

            if (carManager.GetCarDetails().Success == true)
            {
                foreach (var carDetail in carManager.GetCarDetails().Data)
                {
                    Console.WriteLine("Araba Adı: " + carDetail.CarName +
                                      " / Marka Adı: " + carDetail.BrandName +
                                      " / Renk: " + carDetail.ColorName +
                                      " / Günlük Ücret: " + carDetail.DailyPrice);
                }

            }
            else
            {
                Console.WriteLine(carManager.GetCarDetails().Message);
            }
            

            Console.WriteLine("==========BRAND CRUD OPERATION TEST==========");

            //brandManager.Add(brand); //marka ekleme
            //brandManager.Delete(brandManager.GetById(7).Data); //ıd'si verilen markayı db'den silme

            Console.WriteLine("----------Bütün Markaları Listeleme----------");

            if (brandManager.GetAllBrands().Success == true)
            {
                foreach (var brands in brandManager.GetAllBrands().Data)
                {
                    Console.WriteLine(brands.BrandId + " : " + brands.BrandName);
                }
            }
            else
            {
                Console.WriteLine(brandManager.GetAllBrands().Message);
            }

            Console.WriteLine("----------Id'si Verilen Markayı Yazdırma----------");

            var result = brandManager.GetById(2);
            Console.WriteLine(result.Data.BrandName);

            Console.WriteLine(brandManager.GetById(5).Data.BrandName);
            
            Console.WriteLine("==========COLOR CRUD OPERATION TEST==========");

            //colorManager.Add(color); //renk ekleme
            //colorManager.Delete(colorManager.GetById(8).Data); //db'den renk silme

            Console.WriteLine("----------Bütün Renkleri Listeleme----------");

            if (colorManager.GetAllColors().Success == true)
            {
                foreach (var colors in colorManager.GetAllColors().Data)
                {
                    Console.WriteLine(colors.ColorId + " : " + colors.ColorName);
                }
            }
            else
            {
                Console.WriteLine(colorManager.GetAllColors().Message);
            }

        }
    }
}
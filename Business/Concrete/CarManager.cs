using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal; //injection 
        
        public CarManager(ICarDal carDal) //ctor
        {
            _carDal = carDal;
        }

        public void Add(List<Car> cars)
        {
            foreach (var car in cars)
            {
                if (car.DailyPrice > 0 && car.CarName.Length >= 2)
                {
                    _carDal.Add(car);
                    Console.WriteLine("Araçlar sisteme eklendi.");
                }
                else
                {
                    Console.WriteLine("Günlük kiralama bedeli 0'dan büyük, araba ismi minimum 2 karakter olmalıdır!");

                }
            }
            
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            //business conditition/statements blocks

           return _carDal.GetAll();
        }

        public List<Car> GetByDailyPrice(decimal min, decimal max) //verilen fiyat aralıgındaki arabaları listeler.
        {
            return _carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max);
        }

        public Car GetById(int id) //ıd'si verilen aracı getirir.
        {
            return _carDal.Get(c => c.Id == id);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }

        public List<Car> GetCarsByBrandId(int id)  //markaya göre arabaları listeler.
        {
            return _carDal.GetAll(c => c.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id) //renge göre arabaları listeler.
        {
            return _carDal.GetAll(c => c.ColorId == id);
        }
    }
}

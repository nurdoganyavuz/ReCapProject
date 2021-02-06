using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
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
                if (car.DailyPrice > 0)
                {
                    _carDal.Add(car);
                    Console.WriteLine("Araçlar sisteme eklendi.");
                }
                else
                {
                    Console.WriteLine("Günlük kiralama bedeli 0'dan büyük olmalıdır!");

                }
            }
            
        }

        public List<Car> GetAll()
        {
            //business conditition/statements blocks

           return _carDal.GetAll();
        }

        public List<Car> GetByDailyPrice(decimal min, decimal max)
        {
            return _carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max);
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(c => c.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(c => c.ColorId == id);
        }
    }
}

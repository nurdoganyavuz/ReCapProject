using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars; //injection

        public InMemoryCarDal() //ctor
        {
            _cars = new List<Car>
            {
                new Car { Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 500, ModelYear = "2010", Description = "Manuel" },
                new Car { Id = 2, BrandId = 1, ColorId = 2, DailyPrice = 600, ModelYear = "2011", Description = "Otomatik" },
                new Car { Id = 3, BrandId = 2, ColorId = 3, DailyPrice = 700, ModelYear = "2014", Description = "Otomatik" },
                new Car { Id = 4, BrandId = 2, ColorId = 2, DailyPrice = 400, ModelYear = "2009", Description = "Manuel" },
                new Car { Id = 5, BrandId = 3, ColorId = 1, DailyPrice = 750, ModelYear = "2015", Description = "Otomatik" },
            };
        }

        public void Add(Car car) //add to InMemory(_cars) the car
        {
            _cars.Add(car);
        }

        public void Delete(Car car) //Delete car from InMemory(_cars)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);

        }

        public List<Car> GetAll() //listed all cars from InMemory
        {
            return _cars;
        }

        public List<Car> GetById(int Id) //listed according to ıd
        {
            return _cars.Where(c => c.Id == Id).ToList();
        }

        public void Update(Car car) //update the car properties in _cars
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}

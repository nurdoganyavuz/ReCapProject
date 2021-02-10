using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        Car GetById(int id);

        List<Car> GetAll();

        List<Car> GetCarsByBrandId(int id);

        List<Car> GetCarsByColorId(int id);

        List<Car> GetByDailyPrice(decimal min, decimal max);

        void Add(List<Car> cars);

        void Delete(Car car);

        List<CarDetailDto> GetCarDetails();

    }
}

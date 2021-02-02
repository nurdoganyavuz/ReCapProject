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

        public List<Car> GetAll()
        {
            //business conditition/statements blocks

           return _carDal.GetAll();
        }
    }
}

using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            carManager.GetAll();

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id + " numaralı " + car.ModelYear + " model aracın günlük ücreti: " + car.DailyPrice + " TL");
            }
        }
    }
}

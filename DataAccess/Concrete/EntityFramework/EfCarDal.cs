using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             join ci in context.CarImages
                             on c.Id equals ci.CarId
                             select new CarDetailDto
                             {
                                 Id = c.Id,
                                 CarName = c.CarName,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 ModelYear = c.ModelYear,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 ImagePath = ci.ImagePath
                             };
                                  


                return result.ToList();

            }
        }
    }
}

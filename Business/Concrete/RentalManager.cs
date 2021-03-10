using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        [SecuredOperation("admin, moderator, rental.add")]
        public IResult Add(Rental rental)
        {
            if (_rentalDal.GetRentalDetails(r => r.CarId == rental.CarId && r.ReturnDate == null && r.RentDate == rental.RentDate).Count > 0)
            {
                return new ErrorResult(Messages.RentalNotAdded);
            }
            else
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.RentalAdded);
            }
        }
        [CacheRemoveAspect("IRentalService.Get")]
        [SecuredOperation("admin, moderator")]
        public IResult Delete(Rental rental)
        {
            if (rental.ReturnDate != null)
            {
                _rentalDal.Delete(rental);
                return new SuccessResult(Messages.RentalDeleted);
            }
            else
            {
                return new ErrorResult(Messages.RentalNotDeleted);
            }
            
        }
        [CacheAspect]
        [SecuredOperation("admin, moderator")]
        [PerformanceAspect(10)]
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalListed);
        }
        [CacheAspect]
        [SecuredOperation("admin, moderator")]
        [PerformanceAspect(10)]
        public IDataResult<List<RentalDetailDto>> GetRentalDetail()
        {
            
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(), Messages.RentalDetailListed);
        }

        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        [SecuredOperation("admin, moderator, rental.update")]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.UpdatedMessage);
        }
    }
}

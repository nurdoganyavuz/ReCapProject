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
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        [ValidationAspect(typeof(CustomerValidator))]
        [SecuredOperation("moderator, admin")]
        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAddedMessage);
        }
        [SecuredOperation("moderator, admin")]
        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.CustomerDeletedMessage);
        }
        [CacheAspect]
        //[SecuredOperation("moderator, admin")]
        [PerformanceAspect(10)]
        public IDataResult<List<Customer>> GetAllCustomers()
        {
            if (DateTime.Now.Hour == 01)
            {
                return new ErrorDataResult<List<Customer>>(Messages.MaintenanceTime);
            }
            else
            {
                return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.CustomersListed);
            }
        }
        [SecuredOperation("moderator, admin")]
        public IDataResult<Customer> GetById(int id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.CustomerId == id));
        }

        [ValidationAspect(typeof(CustomerValidator))]
        [SecuredOperation("moderator, admin")]
        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Messages.UpdatedMessage);
        }
    }
}

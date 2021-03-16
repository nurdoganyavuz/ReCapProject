using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        [SecuredOperation("image.add, admin")]
        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckImageLimitExceded(carImage.CarId));

            if (result != null)
            {
                return result;
            }

            carImage.ImagePath = FileHelper.Add(file);
            carImage.ImageUploadDate = DateTime.Now;
            _carImageDal.Add(carImage);

            return new SuccessResult(Messages.CarImageUploaded);
        }

        [ValidationAspect(typeof(CarImageValidator))]
        [SecuredOperation("image.update, admin")]
        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Update(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckImageLimitExceded(carImage.CarId), CheckImage(carImage.CarImageId));

            if (result != null)
            {
                return result;
            }
            CarImage oldImage = _carImageDal.Get(ci => ci.CarImageId == carImage.CarImageId);
            carImage.ImagePath = FileHelper.Update(file, oldImage.ImagePath);
            carImage.ImageUploadDate = DateTime.Now;
            carImage.CarId = oldImage.CarId;
            _carImageDal.Update(carImage);
            
            return new SuccessResult(Messages.CarImageUpdated);
        }
        [SecuredOperation("image.delete, admin")]
        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Delete(CarImage carImage)
        {
            
            FileHelper.Delete(_carImageDal.Get(ci => ci.CarImageId == carImage.CarImageId).ImagePath);
            _carImageDal.Delete(carImage);

            return new SuccessResult(Messages.CarImageDeleted);
        }
        [CacheAspect]
        [PerformanceAspect(10)]
        public IDataResult<List<CarImage>> GetAll(Expression<Func<CarImage, bool>> filter = null)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }
        [CacheAspect]
        public IDataResult<List<CarImage>> GetById(int id)
        {
            return new SuccessDataResult<List<CarImage>>(CheckIfCarImageIsNull(id));
        }
        

        //BUSINESS RULES
        private IResult CheckImageLimitExceded(int carId)
        {
            var imageLimit = _carImageDal.GetAll(ci => ci.CarId == carId).Count;
            if (imageLimit >= 5)
            {
                return new ErrorResult(Messages.ImageLimitExceded);
            }

            return new SuccessResult();
        }

        private IResult CheckImage(int imageId)
        {
            var checkImage = _carImageDal.Get(ci => ci.CarImageId == imageId);
            if (checkImage == null)
            {
                return new ErrorResult(Messages.NotFoundImage);
            }
            return new SuccessResult();
        }

        private List<CarImage> CheckIfCarImageIsNull(int carId)
        {
            string imagePath = @"\Images\default.jpg";
            var result = _carImageDal.GetAll(ci => ci.CarId == carId);

            if (result.Any()==false)
            {
                List<CarImage> carImageList = new List<CarImage>();
                carImageList.Add(new CarImage { CarId = carId, ImageUploadDate = DateTime.Now, ImagePath = imagePath });
                return new List<CarImage>(carImageList);
            }

            return result;
        }

    }

}

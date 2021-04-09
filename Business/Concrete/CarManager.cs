using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FludentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using Business.BusinessAspects.Autofac;
using Core.Aspects.Autofac.Caching;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        ICarImageService _carImageService;
        public CarManager(ICarDal carDal, ICarImageService carImageService)
        {
            _carDal = carDal;
            _carImageService = carImageService;

        }
        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarDetailsFilter(int brandId, int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(
                _carDal.GetCarDetails(c => c.BrandId == brandId && c.ColorId == colorId),
                Messages.CarListed);
        }

        // [TransactionalScopeAspect]
        [CacheRemoveAspect("ICarService.Get")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {

            _carDal.Add(car);

            return new SuccessResult(Messages.CarAdded);


        }
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new ErrorResult(Messages.CarDeleted);

        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());

        }

        [CacheAspect]
        public IDataResult<Car> GetById(int CarId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.Id == CarId));
        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarDetail()
        {

            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());

        }
        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarDetailById(int carId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(p => p.Id == carId));

        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarsDetailByBrandId(int BrandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(p => p.BrandId == BrandId));

        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarsByColorId(int ColorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.ColorId == ColorId));

        }

        [CacheRemoveAspect("ICarService.Get")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }


    }
}

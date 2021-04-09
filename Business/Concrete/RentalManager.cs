using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.ValidationRules.FludentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;

namespace Business.Concrete
{

    public class RentalManager : IRentalService
    {
        IRentalDal _rentaldal;

        public RentalManager(IRentalDal rentaldal)
        {
            _rentaldal = rentaldal;
        }


        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            var result = _rentaldal.GetAll(r => r.CarId == rental.CarId && (r.ReturnDate == null || r.ReturnDate < DateTime.Now)).Any();

            if (result)
            {
                return new ErrorResult(Messages.RentedCarAlreadyExists);
            }
            _rentaldal.Add(rental);

            return new SuccessResult(Messages.Added);
        }


        public IResult Delete(Rental rental)
        {
            _rentaldal.Delete(rental);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentaldal.GetAll(), Messages.RentalsListed);
        }

        public IDataResult<List<Rental>> GetByCarId(int carId)
        {
            return new SuccessDataResult<List<Rental>>(_rentaldal.GetAll(r => r.CarId == carId));
        }

        public IDataResult<List<Rental>> GetById(int id)
        {
            return new SuccessDataResult<List<Rental>>(_rentaldal.GetAll(r => r.Id == id));
        }

        public IResult Update(Rental rental)
        {
            _rentaldal.Update(rental);
            return new SuccessResult(Messages.Updated);
        }
    }
}

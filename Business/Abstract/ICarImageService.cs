using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface ICarImageService
    {
        IResult Add(CarImage entity);
        IResult Delete(CarImage entity);
        IResult Update(CarImage entity);
        IDataResult<List<CarImage>> GetAll();
        IDataResult<CarImage> GetById(int carId);
        IDataResult<List<CarImage>> GetAllImagesByCarId(int CarId);
    }
}

using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (CarContext context = new CarContext())
            {
                var result = from c in context.Cars
                    join b in context.Brands
                        on c.BrandId equals b.Id
                    join co in context.Colors
                        on c.ColorId equals co.Id
                    //join ci in context.CarImages
                    //on c.Id equals ci.CarId
                    select new CarDetailDto()
                    {
                        Id = c.Id,
                        Description = c.Description,
                        BrandName = b.BrandName,
                        BrandId = b.Id,
                        ColorId = co.Id,
                        ColorName = co.ColorName,
                        DailyPrice = c.DailyPrice,
                        ModelYear = c.ModelYear,
                        MinFindeksScore =c.MinFindeksScore,
                        ImagePath = (from a in context.CarImages where a.CarId == c.Id select a.ImagePath).FirstOrDefault()

                    };



                return filter == null ? result.ToList() : result.Where(filter).ToList();

            }

        }

    }
}

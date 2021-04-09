using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (CarContext context = new CarContext())
            {
                var result =
                    (from re in context.Rentals
                        join ca in context.Cars on re.CarId equals ca.Id
                        join cu in context.Customers on re.CustomerId equals cu.Id
                        join br in context.Brands on ca.BrandId equals br.Id
                        join us in context.Users on cu.UserId equals us.Id
                        select new RentalDetailDto
                        {
                            Id = re.Id,
                            CarId = ca.Id,
                            BrandName = br.BrandName,
                            Description = ca.Description,
                            CustomerId = cu.Id,
                            FirstName = us.FirstName,
                            LastName = us.LastName,
                            RentDate = re.RentDate,
                            ReturnDate = re.ReturnDate
                        }).ToList();
                return result.ToList();
            }
        }
    }
}

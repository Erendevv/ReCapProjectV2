using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Entities.DTOs;

namespace DataAccess.Concrete
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, CarContext>, ICustomerDal
    {


        public List<CustomerDetailDto> GetCustomerDetails(Expression<Func<Customer, bool>> filter = null)
        {
            using (CarContext context = new CarContext())
            {
                var result = from u in context.Users
                    join c in context.Customers
                        on u.Id equals c.UserId
                    select new CustomerDetailDto
                    {
                        CustomerId = c.Id, FirstName = u.FirstName, LastName = u.LastName, Email = u.Email,
                        CompanyName = c.CompanyName
                    };
                return result.ToList();
            }
        }

 
    }
}

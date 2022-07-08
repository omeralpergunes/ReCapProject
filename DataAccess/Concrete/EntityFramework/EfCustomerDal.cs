using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, ReCapDB>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (ReCapDB reCapDB = new ReCapDB())
            {
                var result =
                    from customer in reCapDB.Customers
                    join user in reCapDB.Users on customer.UserId
                    equals user.Id
                    select new CustomerDetailDto()
                    {

                        UserId = user.Id,
                        CustomerId = customer.UserId,
                        CustomerName = customer.CompanyName,
                        
                    };
                return result.ToList();
            }
        }
    }
}

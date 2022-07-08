using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal: EfEntityRepositoryBase<Rental, ReCapDB>, IRentalDal 
    {
        public List<RentalDetailDto> GetRentalDetail(Expression<Func<Rental, bool>>filter=null)
        {
            using(ReCapDB reCapDB = new ReCapDB())
            {
                var result = from rt in filter == null ? reCapDB.Rentals : reCapDB.Rentals.Where(filter)
                             join ca in reCapDB.Carss on rt.CarId equals ca.CarId
                             join cu in reCapDB.Customers on rt.CustomerId equals cu.UserId
                             join br in reCapDB.Brands on ca.BrandId equals br.BrandId
                             join us in reCapDB.Users on cu.UserId equals us.Id
                             select new RentalDetailDto
                             {
                                 RentalId = rt.Id,
                                 BrandName = br.BrandName,
                                 CompanyName = cu.CompanyName,
                                 CustomerName = us.FirstName + us.LastName,
                                 RentDate = rt.RentDate,
                                 ReturnDate = rt.ReturnDate,


                             };
                return result.ToList();
            }
        }
    }
}

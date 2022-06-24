using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapDB>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapDB reCapDB = new ReCapDB())
            {
                var result = from c in reCapDB.Carss
                             join b in reCapDB.Brands
                             on c.BrandId equals b.brandId
                             join col in reCapDB.Colors
                             on c.ColorId equals col.colorId
                             select new CarDetailDto
                             {
                                 CarName = c.CarName,
                                 BrandName= b.brandName,
                                 ColorName = col.colorName,
                                 DailyPrice = c.DailyPrice

                             };

                return result.ToList();
            }
        }
    }
}

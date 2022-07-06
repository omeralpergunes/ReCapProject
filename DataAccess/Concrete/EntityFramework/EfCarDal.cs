using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapDB>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapDB reCapDB = new ReCapDB())
            {
                var result = from c in reCapDB.Carss
                             join br in reCapDB.Brands
                             on c.BrandId equals br.BrandId
                             join col in reCapDB.Colors
                             on c.ColorId equals col.colorId
                             select new CarDetailDto
                             {
                                 CarName = c.CarName,
                                 BrandName = br.BrandName,
                                 ColorName = col.ColorName,
                                 DailyPrice = c.DailyPrice

                             };

                return result.ToList();
            }
        }
    }
}

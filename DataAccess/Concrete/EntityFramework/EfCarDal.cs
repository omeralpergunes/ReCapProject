using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car car)
        {
            using (ReCapDB reCapDB = new ReCapDB())
            {
                var addedEntity = reCapDB.Entry(car);
                addedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Added;
                reCapDB.SaveChanges();
            }
        }

        public void Delete(Car car)
        {
            using (ReCapDB reCapDB = new ReCapDB())
            {
                var deletedEntity = reCapDB.Entry(car);
               deletedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                reCapDB.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (ReCapDB reCapDB = new ReCapDB())
            {
                return reCapDB.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter=null)
        {
            using (ReCapDB reCapDB = new ReCapDB())
            {
                return filter == null
                    ? reCapDB.Set<Car>().ToList() 
                    : reCapDB.Set<Car>().Where(filter).ToList();
            }
        }

        public void Update(Car car)
        {
            using (ReCapDB reCapDB = new ReCapDB())
            {
                var updatedEntity = reCapDB.Entry(car);
                updatedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                reCapDB.SaveChanges();
            }
        }
    }
}

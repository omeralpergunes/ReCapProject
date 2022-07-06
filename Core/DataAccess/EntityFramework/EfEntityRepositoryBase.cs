using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TRecapDB> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TRecapDB : DbContext, new()
    {
        public void Add(TEntity car)
        {
            using (TRecapDB reCapDB = new TRecapDB())
            {
                var addedEntity = reCapDB.Entry(car);
                addedEntity.State = EntityState.Added;
                reCapDB.SaveChanges();
            }
        }

        public void Delete(TEntity car)
        {
            using (TRecapDB reCapDB = new TRecapDB())
            {
                var deletedEntity = reCapDB.Entry(car);
                deletedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                reCapDB.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TRecapDB reCapDB = new TRecapDB())
            {
                return reCapDB.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TRecapDB reCapDB = new TRecapDB())
            {
                return filter == null
                    ? reCapDB.Set<TEntity>().ToList()
                    : reCapDB.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity car)
        {
            using (TRecapDB reCapDB = new TRecapDB())
            {
                var updatedEntity = reCapDB.Entry(car);
                updatedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                reCapDB.SaveChanges();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CaWe.DB
{
    public class BaseDB<TEntity> where TEntity : class
    {
        #region Fields
        private Repository repository;

        public Repository Repository
        {
            get { return repository ?? (repository = new Repository()); }
        }
        #endregion

        #region Shared

        public TEntity Get(string id)
        {
            return Repository.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Repository.Set<TEntity>().ToList();
        }

        public void Add(TEntity entity)
        {
            Repository.Set<TEntity>().Add(entity);
            Repository.SaveChanges();
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            Repository.Set<TEntity>().AddRange(entities);
            Repository.SaveChanges();
        }

        public void Remove(TEntity entity)
        {
            Repository.Set<TEntity>().Remove(entity);
            Repository.SaveChanges();
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Repository.Set<TEntity>().RemoveRange(entities);
            Repository.SaveChanges();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Repository.Set<TEntity>().Where(predicate);
        }

        public void Update(TEntity entity)
        {
            if (entity == null)
                return;

            TEntity dbEntity = Repository.Set<TEntity>().Find(entity.GetType().GetProperty("UniquePropFormBaseentity(CONSTANT)").GetValue(entity));

            Repository.Entry(dbEntity).CurrentValues.SetValues(entity);
            Repository.SaveChanges();
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            if (entities == null || entities.Count() == 0)
                return;

            for (int i = 0; i < entities.Count(); i++)
            {
                TEntity dbEntity = Repository.Set<TEntity>().Find(entities.ElementAt(i).GetType().GetProperty("UniquePropFormBaseentity(CONSTANT)").GetValue(entities.ElementAt(i)));
                Repository.Entry(dbEntity).CurrentValues.SetValues(entities.ElementAt(i));
            }
            Repository.SaveChanges();
        }

        #endregion
    }
}

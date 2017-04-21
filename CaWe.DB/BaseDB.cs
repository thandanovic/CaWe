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
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            Repository.Set<TEntity>().AddRange(entities);
        }

        public void Remove(TEntity entity)
        {
            Repository.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Repository.Set<TEntity>().RemoveRange(entities);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Repository.Set<TEntity>().Where(predicate);
        }

        public void Update(TEntity entity)
        {
            if (entity == null)
                return;

            TEntity enttity = Repository.Set<TEntity>().Find(entity.GetType().GetProperty("UserId").GetValue(entity));

            Repository.Entry(enttity).CurrentValues.SetValues(entity);
            Repository.SaveChanges();
        }

        public int Save()
        {
            return Repository.SaveChanges();
        }

        public void Dispose()
        {
            Repository.Dispose();
        }

        #endregion
    }
}

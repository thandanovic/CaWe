using CaWe.DB;
using CaWe.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CaWe.Manager
{
    public class BaseManager<TEntity> where TEntity : class
    {
        #region Fields
        private BaseDB<TEntity> baseDB;

        private BaseDB<TEntity> BaseDB
        {
            get { return baseDB ?? (baseDB = new BaseDB<TEntity>()); }
        }
        #endregion

        #region Shared

        public TEntity Get(string id)
        {
            return BaseDB.Get(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return BaseDB.GetAll();
        }

        public void Add(TEntity entity)
        {
            BaseDB.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            BaseDB.AddRange(entities);
        }

        public void Remove(TEntity entity)
        {
            BaseDB.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            BaseDB.RemoveRange(entities);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return BaseDB.Find(predicate);
        }

        public void Update(TEntity entity)
        {
            BaseDB.Update(entity);
        }

        public int Save()
        {
            return BaseDB.Save();
        }

        public void Dispose()
        {
            BaseDB.Dispose();
        }

        #endregion
    }

    #region Partials

    public partial class UserManager : BaseManager<User> { }

    public partial class UserRoleManager : BaseManager<UserRole> { }

    public partial class RoleManager : BaseManager<Role> { }

    #endregion
}

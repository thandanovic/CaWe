using CaWe.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaWe.Manager
{
    public class BaseManager<TEntity> where TEntity : class
    {
        private BaseDB<TEntity> baseDB;

        public BaseDB<TEntity> BaseDB
        {
            get { return baseDB ?? (baseDB = new BaseDB<TEntity>()); }
        }

        public TEntity Get(string id)
        {
            return BaseDB.Get(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return BaseDB.GetAll();
        }
    }
}

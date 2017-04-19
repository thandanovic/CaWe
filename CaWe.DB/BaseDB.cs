using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaWe.DB
{
    public class BaseDB<TEntity> where TEntity : class
    {
        private Repository repository;

        public Repository Repository
        {
            get { return repository ?? (repository = new Repository()); }
        }

        public TEntity Get(string id)
        {
            return Repository.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Repository.Set<TEntity>().ToList();
        }
        //update delete also
    }
}

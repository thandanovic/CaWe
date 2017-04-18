using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaWe.Entities;

namespace CaWe.DB
{
    class Repository : DbContext
    {
        public Repository() : base("CaWeDb")
        {

        }

        public DbSet<User> Users { get; set; }
    }
}

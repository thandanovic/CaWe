using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaWe.Entities;

namespace CaWe.DB
{
    public class Repository : DbContext
    {
        public Repository() : base("CaWeDb")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        #region Partials

        public partial class UserDB : BaseDB<User> { }
        public partial class UserRoleDB : BaseDB<UserRole> { }
        public partial class RoleDB : BaseDB<Role> { }

        #endregion
    }
}

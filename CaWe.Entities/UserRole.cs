using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaWe.Entities
{
    public class UserRole: BaseEntity
    {
        public string UserRoleId { get; set; }
        public string UserId { get; set; }
        public string RoleId { get; set; }

        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}

using CaWe.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaWe.Entities
{
    public class Role : BaseEntity, IRole
    {
        public string RoleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

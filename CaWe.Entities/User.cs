using CaWe.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaWe.Entities
{
    public class User : BaseEntity, IUser
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
    }

   
}

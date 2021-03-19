using SCI.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Core.Entities {
    public class User : BaseEntity, IFullAccess {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }

        public Role Role { get; set; }
    }
}

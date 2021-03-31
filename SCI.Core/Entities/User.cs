using Microsoft.AspNetCore.Identity;
using SCI.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Core.Entities {
    public class User : IdentityUser {

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Company Company { get; set; }
    }
}

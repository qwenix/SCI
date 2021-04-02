using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Core.Entities {
    public class User : IdentityUser<int> {
        public Company Company { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}

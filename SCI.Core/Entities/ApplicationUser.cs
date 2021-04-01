using Microsoft.AspNetCore.Identity;
using SCI.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Core.Entities {
    public class ApplicationUser : BaseEntity {

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public User User { get; set; }
        public Driver Driver { get; set; }
    }
}

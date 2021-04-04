using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCI.WebAPI.Models.Auth {
    public class CompanyRegistrationRequest {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}

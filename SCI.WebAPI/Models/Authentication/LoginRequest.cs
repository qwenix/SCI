using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCI.WebAPI.Models.Authentication {
    public class LoginRequest {
        public string Email { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
    }
}

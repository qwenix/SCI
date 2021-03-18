using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SCI.Infrastructure.Entities;

namespace SCI.WebAPI.Models.Authentication {
    public class AuthenticationResponse {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }

        public AuthenticationResponse(User user, string token) {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
            Token = token;
        }
    }
}

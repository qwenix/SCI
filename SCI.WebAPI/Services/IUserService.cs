using SCI.Infrastructure.Entities;
using SCI.WebAPI.Models.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.WebAPI.Interfaces {
    public interface IUserService {

        AuthenticationResponse Authenticate(AuthenticationRequest model);
        Task<AuthenticationResponse> Register(UserModel userModel);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }
}

using SCI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Core.Interfaces.Services {
    public interface IAuthService {

        public User FindUser(string email);
        public Task<User> FindUserAsync(string email);
    }
}

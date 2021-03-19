using SCI.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Core.Interfaces.Services {
    public interface IUserService {

        public UserDTO GetByEmail(string email);
        public Task<UserDTO> GetByEmailAsync(string email);
    }
}

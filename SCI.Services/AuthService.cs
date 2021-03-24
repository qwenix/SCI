using AutoMapper;
using SCI.Core.Entities;
using SCI.Core.Interfaces.Repositories;
using SCI.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Services {
    class AuthService : IAuthService {

        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public AuthService(IMapper mapper, IUserRepository userRepository) {
            this.mapper = mapper;
            this.userRepository = userRepository;
        }
        
        public User FindUser(string email) {
            throw new NotImplementedException();
        }

        public async Task<User> FindUserAsync(string email) {
            User user = await userRepository.FirstIncludedAsync(u => u.Email == email);
            return mapper.Map<User>(user);
        }
    }
}

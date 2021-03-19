using AutoMapper;
using SCI.Core.DTOs;
using SCI.Core.Entities;
using SCI.Core.Interfaces.Repositories;
using SCI.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Core.Services {
    class UserService : IUserService {

        private readonly IDataAccessRepository<User> dataAccessRepository;
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UserService(IMapper mapper,
            IDataAccessRepository<User> dataAccessRepository, 
            IUserRepository userRepository) {
            this.dataAccessRepository = dataAccessRepository;
            this.mapper = mapper;
            this.userRepository = userRepository;
        }
        
        public UserDTO GetByEmail(string email) {
            throw new NotImplementedException();
        }

        public async Task<UserDTO> GetByEmailAsync(string email) {
            User user = await userRepository.FirstIncludedAsync(u => u.Email == email);
            return mapper.Map<UserDTO>(user);
        }
    }
}

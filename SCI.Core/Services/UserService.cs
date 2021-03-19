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
        private readonly IMapper mapper;

        public UserService(IDataAccessRepository<User> dataAccessRepository, IMapper mapper) {
            this.dataAccessRepository = dataAccessRepository;
            this.mapper = mapper;
        }
        
        public UserDTO GetByEmail(string email) {
            throw new NotImplementedException();
        }

        public async Task<UserDTO> GetByEmailAsync(string email) {
            IEnumerable<User> users = await dataAccessRepository.GetAllAsync();
            return mapper.Map<UserDTO>(users.First(u => u.Email == email));
        }
    }
}

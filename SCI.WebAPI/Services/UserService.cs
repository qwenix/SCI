using AutoMapper;
using Microsoft.Extensions.Configuration;
using SCI.Infrastructure.Entities;
using SCI.Interfaces;
using SCI.WebAPI;
using SCI.WebAPI.Interfaces;
using SCI.WebAPI.Models.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.WebAPI.Services {
    public class UserService : IUserService {

        private readonly IRepository<User> userRepository;
        private readonly IConfiguration configuration;
        private readonly IMapper mapper;

        public UserService(IRepository<User> userRepository, 
            IConfiguration configuration, IMapper mapper) {
            this.userRepository = userRepository;
            this.configuration = configuration;
            this.mapper = mapper;
        }

        public AuthenticationResponse Authenticate(AuthenticationRequest model) {
            var user = userRepository
                .GetAll()
                .FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);

            if (user == null) {
                // todo: need to add logger
                return null;
            }

            var token = configuration.GenerateJwtToken(user);

            return new AuthenticationResponse(user, token);
        }

        public async Task<AuthenticationResponse> Register(UserModel userModel) {
            var user = mapper.Map<User>(userModel);

            var addedUser = await userRepository.Add(user);

            var response = Authenticate(new AuthenticationRequest {
                Email = user.Email,
                Password = user.Password
            });

            return response;
        }

        public IEnumerable<User> GetAll() {
            return userRepository.GetAll();
        }

        public User GetById(int id) {
            return userRepository.GetById(id);
        }
    }
}

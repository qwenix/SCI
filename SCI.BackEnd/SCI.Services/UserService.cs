using Microsoft.AspNetCore.Identity;
using SCI.Core.Constants;
using SCI.Core.Entities;
using SCI.Core.Interfaces.Repositories;
using SCI.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Services {
    public class UserService : IUserService {

        private readonly IUserRepository identityRepository;

        public UserService(IUserRepository identityRepository) {
            this.identityRepository = identityRepository;
        }

        public async Task DeleteDriverAsync(string username) {
            await DeleteIfInRoleAsync(username, Roles.DRIVER);
        }

        public async Task DeleteCompanyAsync(string username) {
            await DeleteIfInRoleAsync(username, Roles.COMPANY);
        }

        public async Task DeleteAdminAsync(string username) {
            await DeleteIfInRoleAsync(username, Roles.ADMIN);
        }

        private async Task DeleteIfInRoleAsync(string username, string roleName) {
            User identity = await identityRepository.FindByUsernameAsync(username);
            IList<string> roles = await identityRepository.GetRolesAsync(identity);
            string role = roles.First();
            if (role == roleName) {
                IdentityResult result = await identityRepository.DeleteByUsernameAsync(username);
                if (!result.Succeeded) {
                    throw new Exception(result.Errors.First().Description);
                }
            }
            else {
                throw new Exception($"User role is {role} not {roleName}");
            }
        }
    }
}

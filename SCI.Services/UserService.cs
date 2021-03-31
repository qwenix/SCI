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

        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository) {
            this.userRepository = userRepository;
        }

        public async Task DeleteUserAsync(string username) {
            await DeleteIfInRoleAsync(username, Roles.USER);
        }

        public async Task DeleteCompanyAdminAsync(string username) {
            await DeleteIfInRoleAsync(username, Roles.COMPANY_ADMIN);
        }

        public async Task DeleteAdminAsync(string username) {
            await DeleteIfInRoleAsync(username, Roles.ADMIN);
        }

        private async Task DeleteIfInRoleAsync(string username, string roleName) {
            User user = await userRepository.FindByUsernameAsync(username);
            IList<string> userRoles = await userRepository.GetRolesAsync(user);
            string userRole = userRoles.First();
            if (userRole == roleName) {
                IdentityResult result = await userRepository.DeleteByUsernameAsync(username);
                if (!result.Succeeded) {
                    throw new Exception(result.Errors.First().Description);
                }
            }
            else {
                throw new Exception($"User role is {userRole} not {roleName}");
            }
        }
    }
}

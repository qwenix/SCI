using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SCI.Core.Entities;
using SCI.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Infrastructure.EF.Repositories {
    public class UserRepository : IUserRepository {

        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserRepository(UserManager<User> userManager, 
            RoleManager<IdentityRole> roleManager) {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<IdentityResult> AddUserToRoleAsync(User user, string roleName) {
            return await userManager.AddToRoleAsync(user, roleName);
        }

        public async Task<IdentityResult> AddUserAsync(User user, string password) {
            return await userManager.CreateAsync(user, password);
        }

        public async Task<IdentityResult> AddRoleAsync(IdentityRole role) {
            return await roleManager.CreateAsync(role);
        }

        public async Task<User> FindByUsernameAsync(string username) {
            return await userManager.FindByNameAsync(username);
        }

        public async Task<bool> CheckPasswordAsync(User user, string password) {
            return await userManager.CheckPasswordAsync(user, password);
        }

        public async Task<IList<string>> GetRolesAsync(User user) {
            return await userManager.GetRolesAsync(user);
        }

        public async Task<IdentityResult> DeleteByUsernameAsync(string username) {
            User user = await FindByUsernameAsync(username);
            if (user is null) {
                throw new Exception($"There is no User with username \"{username}\"");
            }
            return await userManager.DeleteAsync(user);
        }
    }
}

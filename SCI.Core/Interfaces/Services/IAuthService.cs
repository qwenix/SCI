using Microsoft.AspNetCore.Identity;
using SCI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Core.Interfaces.Services {
    public interface IAuthService {

        Task RegisterUserAsync(User user, string roleName, string password);
        Task RegisterAdminAsync(User user);
        Task RegisterCompanyAsync(Company company, User CompanyAdmin);

        /// <returns>Refresh Token</returns>
        Task<string> LoginAsync(string username, string password);

        Task CreateRoleAsync(IdentityRole role);
    }
}

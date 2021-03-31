using Microsoft.AspNetCore.Identity;
using SCI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Core.Interfaces.Repositories {
    public interface IUserRepository {
        Task<IdentityResult> AddUserToRoleAsync(User user, string roleName);
        Task<IdentityResult> AddUserAsync(User user, string password);
        Task<IdentityResult> AddRoleAsync(IdentityRole role);
    }
}

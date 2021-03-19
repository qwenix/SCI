using Microsoft.Extensions.DependencyInjection;
using SCI.Core.DTOs;
using SCI.Core.Entities;
using SCI.Core.Interfaces.Services;
using SCI.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Core.Extensions {
    public static class DiServiceExtensions {

        public static void AddCoreServices(this IServiceCollection services) {
            services.AddTransient<DataAccessService<User>, UserDataAccessService>();
            services.AddTransient<DataAccessService<Role>, RoleDataAccessService>();
            services.AddTransient<IUserService, UserService>();
        }
    }
}

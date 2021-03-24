using Microsoft.Extensions.DependencyInjection;
using SCI.Core.Entities;
using SCI.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Services.Extensions {
    public static class DiExtensions {

        public static void AddCoreServices(this IServiceCollection services) {
            services.AddTransient<IDataAccessService<User>, UserDataAccessService>();
            services.AddTransient<IAuthService, AuthService>();
        }
    }
}

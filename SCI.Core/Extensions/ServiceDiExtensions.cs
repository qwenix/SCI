using Microsoft.Extensions.DependencyInjection;
using SCI.Core.Interfaces;
using SCI.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Core.Extensions {
    public static class ServiceDiExtensions {

        public static void AddAuthService(this IServiceCollection services) {
            services.AddTransient<IAuthService, AuthService>();
        }

    }
}

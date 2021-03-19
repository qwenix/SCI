using Microsoft.Extensions.DependencyInjection;
using SCI.Core.Interfaces;
using System;

namespace SCI.DI {
    public static class ServiceExtensions {

        public static void AddAuthService(this IServiceCollection services) {
            services.AddTransient(IAuthService);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SCI.Core.DTOs;
using SCI.Core.Entities;
using SCI.Core.Interfaces.Repositories;
using SCI.Infrastructure.Contexts;
using SCI.Infrastructure.Repositories.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.SharedKernel.Extensions {
    public static class DiExtensions {
        public static void AddRepositories(this IServiceCollection services) {
            services.AddTransient<IDataAccessRepository<User>, EfUserRepository>();
            services.AddTransient<IDataAccessRepository<Role>, EfRoleRepository>();
            services.AddTransient<IUserRepository, EfUserRepository>();
        }

        public static void AddMainDbContext(this IServiceCollection services, 
            Action<DbContextOptionsBuilder> options) {
            services.AddDbContext<SciContext>(options);
            services.AddScoped<DbContext, SciContext>();
        }
    }
}

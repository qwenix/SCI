using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SCI.Infrastructure.EF;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCI.Core.Interfaces.Repositories;
using SCI.Core.Entities;
using SCI.Infrastructure.EF.Repositories;

namespace SCI.Infrastructure.Extensions {
    public static class DiExtensions {

        public static void AddRepositories(this IServiceCollection services) {
            services.AddTransient<IUserRepository, UserRepository>();
        }

        public static void AddMainDbContext(this IServiceCollection services,
            IConfiguration configuration) {
            services.AddDbContext<SciContext>(options => {
                string connection = configuration.GetConnectionString("SciConnection");
                options.UseSqlServer(connection);
            });
            services.AddScoped<DbContext, SciContext>();
        }
    }
}

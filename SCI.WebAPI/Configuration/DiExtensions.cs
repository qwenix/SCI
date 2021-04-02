using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using SCI.Core.Constants;
using SCI.Core.Entities;
using SCI.Core.Interfaces.Repositories;
using SCI.Core.Interfaces.Services;
using SCI.Infrastructure.EF;
using SCI.Infrastructure.EF.Repositories;
using SCI.Services;
using SCI.Services.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.WebAPI.Configuration {
    public static class DiExtensions {

        public static void AddSwager(this IServiceCollection services) {
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo {
                    Title = "SCI.WebAPI",
                    Version = "v1"
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme() {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."
                });

                var scheme = new OpenApiSecurityScheme {
                    Reference = new OpenApiReference {
                        Id = "Bearer",
                        Type = ReferenceType.SecurityScheme
                    }
                };

                var requirements = new OpenApiSecurityRequirement {
                    { scheme, new List<string>() }
                };

                c.AddSecurityRequirement(requirements);
            });
        }

        public static void AddRepositories(this IServiceCollection services) {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ICompanyRepository, CompanyRepository>();
            services.AddTransient<IApplicationUserRepository, ApplicationUserRepository>();
            services.AddTransient<IDriverRepository, DriverRepository>();
            services.AddTransient<IRideRepository, RideRepository>();
        }

        public static void AddCoreServices(this IServiceCollection services) {
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAdminService, AdminService>();
            services.AddTransient<IDriverService, DriverService>();
            services.AddTransient<IConvolutionService, ConvolutionService>();
            services.AddTransient<IDriverStyleService, DriverStyleService>();

            services.AddSingleton<IPasswordGenerator, PasswordGenerator>();
            services.AddSingleton<IRefreshTokenFactory, RefreshTokenFactory>();
        }

        public static void AddMainDbContext(this IServiceCollection services,
            IConfiguration configuration) {
            services.AddDbContext<SciContext>(options => {
                string connection = configuration.GetConnectionString(
                    AppSettingsStrings.MAIN_CONNECTION);
                options.UseSqlServer(connection);
            });
            services.AddScoped<DbContext, SciContext>();
        }

        public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services) {
            services.AddIdentity<User, IdentityRole<int>>(
                config => {
                    config.User.RequireUniqueEmail = true;
                    config.Password.RequireNonAlphanumeric = false;
                    config.Password.RequireDigit = false;
                })
                .AddEntityFrameworkStores<SciContext>();
            return services;
        }

        public static IServiceCollection AddJwtAuth(this IServiceCollection services, 
            IConfiguration configuration) {
            var tokenProvider = new JwtTokenGenerator(configuration);

            services.AddSingleton<ITokenGenerator>(tokenProvider);
            services.AddAuthentication(options => {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(
                    authenticationScheme: JwtBearerDefaults.AuthenticationScheme,
                    configureOptions: options => {
                        options.RequireHttpsMetadata = true;
                        options.TokenValidationParameters = tokenProvider.TokenValidationParameters;
                    });

            return services;
        }
    }
}

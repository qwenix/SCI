using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Web;
using Microsoft.OpenApi.Models;
using SCI.Infrastructure.EF;
using SCI.Infrastructure.Repositories;
using SCI.WebAPI.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCI.WebAPI {
    public class Startup {
        private const string SWAGGER_VERSION = "v1";
        private const string SWAGGER_TITLE = "SCI.WebAPI";
        private const string SWAGGER_ENDPOINT_URL = "/swagger/v1/swagger.json";
        private const string SWAGGER_ENDPOINT_NAME = "SCI.WebAPI v1";

        private const string CONNECTION_STRING = "SciConnection";

        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services) {
            services.AddDbContext<SciContext>(options => {
                string connection = Configuration.GetConnectionString(CONNECTION_STRING);
                options.UseSqlServer(connection);
                }
            );

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => {
                    options.LoginPath = "/login";
                    options.AccessDeniedPath = "/denied";
                    options.Events = new CookieAuthenticationEvents() {
                        OnSignedIn = async context => {
                            await Task.CompletedTask;
                        },
                        OnValidatePrincipal = async context => {
                            await Task.CompletedTask;
                        }
                    };
                });

            services.AddCors();
            services.AddControllers();
            services.AddSwaggerGen(c => {
                c.SwaggerDoc(SWAGGER_VERSION, new OpenApiInfo { 
                    Title = SWAGGER_TITLE, 
                    Version = SWAGGER_VERSION 
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => {
                    c.SwaggerEndpoint(SWAGGER_ENDPOINT_URL, SWAGGER_ENDPOINT_NAME);
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}

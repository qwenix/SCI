using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SCI.Core.Constants;
using SCI.Core.Entities;
using SCI.Core.Extensions;
using SCI.Core.Interfaces;
using SCI.Core.Interfaces.Services;
using SCI.Core.Models;
using SCI.WebAPI.Models;
using SCI.WebAPI.Models.Auth;
using SCI.WebAPI.Models.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SCI.WebAPI.Controllers {

    public class AuthController : ControllerBase {

        private readonly IAuthService authService;
        private readonly IMapper mapper;

        public AuthController(IAuthService authService, IMapper mapper) {
            this.authService = authService;
            this.mapper = mapper;
        }


        [Authorize(Roles = Roles.GOD)]
        [HttpPost("registerAdmin")]
        public async Task<IActionResult> RegisterAdminAsync([FromBody] AdminRegistrationRequest request) {
            if (ModelState.IsValid) {
                var user = mapper.Map<ApplicationUser>(request).SetId();
                await authService.RegisterAdminAsync(user);
                return Ok();
            }
            return ValidationProblem(ModelState);
        }

        [AllowAnonymous]
        [HttpPost("registerDriver")]
        public async Task<IActionResult> RegisterDriverAsync([FromBody] DriverRegistrationRequest request) {
            if (ModelState.IsValid) {
                var driver = mapper.Map<Driver>(request).SetId();
                await authService.RegisterDriverAsync(driver, request.Password);
                return Ok();
            }
            return ValidationProblem(ModelState);
        }

        [Authorize(Roles = Roles.GOD + "," + Roles.ADMIN)]
        [HttpPost("registerCompany")]
        public async Task<IActionResult> RegisterCompanyAsync([FromBody] CompanyRegistrationRequest request) {
            if (ModelState.IsValid) {
                var company = mapper.Map<Company>(request).SetId();
                await authService.RegisterCompanyAsync(company);
                return Ok();
            }
            return ValidationProblem(ModelState);
        }

        [HttpPost("registerGod")]
        public async Task<IActionResult> RegisterGodAsync() {
            await authService.CreateRoleAsync(new IdentityRole { Name = Roles.GOD });
            await authService.CreateRoleAsync(new IdentityRole { Name = Roles.COMPANY });
            await authService.CreateRoleAsync(new IdentityRole { Name = Roles.ADMIN });
            await authService.CreateRoleAsync(new IdentityRole { Name = Roles.DRIVER });

            var identity = new User {
                Email = "denys.kravtsov@nure.ua"
            };
            identity.UserName = identity.Email;

            await authService.RegisterUserAsync(identity, Roles.GOD, "ujlpts5E2088");
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ObjectResult> LoginAsync([FromBody] LoginRequest request) {
            TokensInfo tokensInfo = await authService.LoginAsync(request.Email, request.Password);

            HttpContext.Response.Cookies.Append("refreshToken", tokensInfo.RefreshToken, 
                new CookieOptions {
                    HttpOnly = true,
                    Secure = true
                });

            return Ok(tokensInfo.AccessToken);
        }

    }
}

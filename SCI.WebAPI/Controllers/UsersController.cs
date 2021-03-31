using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SCI.Core.Constants;
using SCI.Core.Entities;
using SCI.Core.Interfaces;
using SCI.Core.Interfaces.Services;
using SCI.WebAPI.Constants;
using SCI.WebAPI.Models;
using SCI.WebAPI.Models.Auth;
using SCI.WebAPI.Models.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SCI.WebAPI.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase {

        private readonly IAuthService authService;
        private readonly IMapper mapper;

        public UsersController(IAuthService userService, IMapper mapper) {
            this.authService = userService;
            this.mapper = mapper;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("registerAdmin")]
        public async Task<IActionResult> RegisterAdminAsync([FromBody] AdminRegistrationRequest request) {
            if (ModelState.IsValid) {
                var user = mapper.Map<User>(request);
                await authService.RegisterAdminAsync(user);
                return Ok();
            }
            return ValidationProblem(ModelState);
        }

        [HttpPost("registerUser")]
        public async Task<IActionResult> RegisterUserAsync([FromBody] UserRegistrationRequest request) {
            if (ModelState.IsValid) {
                var user = mapper.Map<User>(request);
                await authService.RegisterUserAsync(user, Roles.USER, request.Password);
                return Ok();
            }
            return ValidationProblem(ModelState);
        }

        [HttpPost("registerCompany")]
        public async Task<IActionResult> RegisterCompanyAsync([FromBody] CompanyRegistrationRequest request) {
            if (ModelState.IsValid) {
                var company = mapper.Map<Company>(request);
                var user = mapper.Map<User>(request);
                await authService.RegisterCompanyAsync(company, user);
                return Ok();
            }
            return ValidationProblem(ModelState);
        }

        [HttpPost("registerGod")]
        public async Task<IActionResult> RegisterGod() {
            await authService.CreateRoleAsync(new IdentityRole { Name = Roles.GOD });
            await authService.CreateRoleAsync(new IdentityRole { Name = Roles.COMPANY_ADMIN });
            await authService.CreateRoleAsync(new IdentityRole { Name = Roles.ADMIN });
            await authService.CreateRoleAsync(new IdentityRole { Name = Roles.USER });

            var user = new User {
                Email = "denys.kravtsov@nure.ua",
                FirstName = "Denys",
                LastName = "Kravtsov"
            };
            user.UserName = user.Email;

            await authService.RegisterUserAsync(user, Roles.GOD, "ujlpts5E2088");
            return Ok();
        }

        //[AllowAnonymous]
        //[HttpPost("login")]
        //public async Task<ObjectResult> LoginAsync([FromBody] LoginRequestDTO request) {
        //    var response = await authService.LoginAsync(request);

        //    HttpContext.Response.Cookies.Append("refreshToken", response.RefreshToken, new CookieOptions {
        //        HttpOnly = true,
        //        Secure = true
        //    });
        //    return Ok(response.Token);
        //}

        //[HttpPost("login")]
        //public async Task<IActionResult> Validate([FromBody] LoginRequest request) {
        //    User user = await authService.FindUserAsync(request.Email);
        //    var userModel = mapper.Map<UserModel>(user);

        //    if (userModel == null) {
        //        return ValidationProblem(Messages.EMAIL_NOT_EXIST);
        //    }

        //    var claims = new List<Claim>() {
        //        new Claim(ClaimTypes.Email, request.Email),
        //        new Claim(ClaimTypes.Role, userModel.Role)
        //    };
            
        //    var claimsIdentity = new ClaimsIdentity(claims, 
        //        CookieAuthenticationDefaults.AuthenticationScheme);
        //    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
        //    await HttpContext.SignInAsync(claimsPrincipal);

        //    return Ok();
        //}

        //[Authorize]
        //[HttpPost("logout")]
        //public async Task<IActionResult> Logout() {
        //    await HttpContext.SignOutAsync();
        //    return Ok();
        //}
    }
}

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCI.Core.Interfaces;
using SCI.WebAPI.Constants;
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

        private IAuthService authService;

        public UsersController(IAuthService authService) {
            this.authService = authService;
        }

        [HttpGet("login")]
        public IActionResult Login(LoginResponse response) {
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Validate(LoginRequest request) {


            if (!authService.IsEmailExist(request.Email)) {
                return ValidationProblem(Messages.EMAIL_NOT_EXIST);
            }

            var claims = new List<Claim>() {
                new Claim(ClaimTypes.Email, request.Email),
                new Claim(ClaimTypes.Role, request.Role)
            };
            
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            await HttpContext.SignInAsync(claimsPrincipal);

            return Ok();
        }

        [Authorize]
        public async Task<IActionResult> Logout() {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}

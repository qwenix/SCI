using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SCI.Core.DTOs;
using SCI.Core.Entities;
using SCI.Core.Interfaces;
using SCI.Core.Interfaces.Services;
using SCI.WebAPI.Constants;
using SCI.WebAPI.Models;
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

        private readonly DataAccessService<User> dataAccessService;
        private readonly IUserService userService;
        private readonly IMapper mapper;
        private readonly DbContext context;

        public UsersController(DataAccessService<User> dataAccessService, 
            IUserService userService, IMapper mapper, DbContext context) {
            this.context = context;
            this.userService = userService;
            this.mapper = mapper;
            this.dataAccessService = dataAccessService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Validate([FromBody] LoginRequest request) {
            UserDTO userDTO = await userService.GetByEmailAsync(request.Email);
            var userModel = mapper.Map<UserModel>(userDTO);

            if (userModel == null) {
                return ValidationProblem(Messages.EMAIL_NOT_EXIST);
            }

            var claims = new List<Claim>() {
                new Claim(ClaimTypes.Email, request.Email),
                new Claim(ClaimTypes.Role, userModel.Role)
            };
            
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            await HttpContext.SignInAsync(claimsPrincipal);

            return Ok();
        }

        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout() {
            await HttpContext.SignOutAsync();
            return Ok();
        }
    }
}

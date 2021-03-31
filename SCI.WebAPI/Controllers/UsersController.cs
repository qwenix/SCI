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
using SCI.Core.Interfaces;
using SCI.Core.Interfaces.Services;
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
    public partial class UsersController : ControllerBase {

        private readonly IMapper mapper;
        private readonly IUserService userService;

        public UsersController(
            IAuthService authService, 
            IUserService userService,
            IMapper mapper) {
            this.authService = authService;
            this.mapper = mapper;
            this.userService = userService;
        }

        [Authorize(Roles = Roles.ADMIN + "," + Roles.GOD)]
        public Task<IActionResult> DeleteUserAsync(string username) {

        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCI.Core.Constants;
using SCI.Core.Interfaces.Services;
using SCI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCI.WebAPI.Controllers {

    [ApiController]
    [Route("[controller]")]
    public class DriverController : Controller {

        private readonly IDriverService driverService;

        public DriverController(IDriverService driverService) {
            this.driverService = driverService;
        }

        [HttpGet("review")]
        public async Task<IActionResult> GetReview(string username, int daysPeriod) {
            return Ok(await driverService.GetReviewAsync(username, daysPeriod));
        }

        [HttpGet("info")]
        public async Task<IActionResult> GetDriver(string username) {
            return Ok(await driverService.GetByUsernameAsync(username));
        }
    }
}

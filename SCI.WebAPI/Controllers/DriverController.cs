using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCI.Core.Constants;
using SCI.Core.Entities;
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
        private readonly IDriverStyleService drivingStyleService;

        public DriverController(IDriverService driverService,
            IDriverStyleService drivingStyleService) {
            this.driverService = driverService;
            this.drivingStyleService = drivingStyleService;
        }

        [HttpGet("review")]
        public async Task<IActionResult> GetReview(string username, int? daysPeriod = null) {
            return Ok(await driverService.GetReviewAsync(username, daysPeriod));
        }

        [HttpGet("info")]
        public async Task<IActionResult> GetByUsername(string username) {
            return Ok(await driverService.GetByUsernameAsync(username));
        }

        [HttpGet("rate")]
        public async Task<IActionResult> GetDriverStyleRateByUsername(string username, int? daysPeriod = null) {
            DriverRidesReview driverRidesReview = await driverService.GetReviewAsync(username, daysPeriod);
            return Ok(await drivingStyleService.GetDriverStyleReview(driverRidesReview));
        }
    }
}

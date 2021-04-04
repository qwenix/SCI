using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCI.Core.Constants;
using SCI.Core.Entities;
using SCI.Core.Interfaces.Repositories;
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
        private readonly IDriverRepository driverRepository;

        public DriverController(IDriverService driverService,
            IDriverStyleService drivingStyleService,
            IDriverRepository driverRepository) {
            this.driverService = driverService;
            this.drivingStyleService = drivingStyleService;
            this.driverRepository = driverRepository;
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

        [HttpGet("discount")]
        public async Task<IActionResult> GetDiscountByScore(string username, double score) {
            var driver = await driverRepository.GetByUsernameWithCompany(username);
            return Ok(score / 100 * driver.Company.MaxDiscountPersentage);
        }
    }
}

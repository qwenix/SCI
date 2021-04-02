using Microsoft.AspNetCore.Mvc;
using SCI.Core.Entities;
using SCI.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCI.WebAPI.Controllers {

    [ApiController]
    [Route("[controller]")]
    public class RideController : Controller {

        private readonly IRideRepository rideRepository;

        public RideController(IRideRepository rideRepository) {
            this.rideRepository = rideRepository;
        }

        [HttpPost("addRide")]
        public async Task<IActionResult> AddRide([FromBody] Ride ride) {
            await rideRepository.AddAsync(ride);
            await rideRepository.SaveChangesAsync();
            return Ok();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using SCI.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCI.WebAPI.Controllers {
    public class DriverController : Controller {

        private readonly IDriverService driverService;

        public DriverController(IDriverService driverService) {
            this.driverService = driverService;
        }

        public IActionResult GetDriverRewiew(string driverUsername, int daysPeriod) {
            driverService.GetDriverReview(driverUsername, daysPeriod);
        }
    }
}

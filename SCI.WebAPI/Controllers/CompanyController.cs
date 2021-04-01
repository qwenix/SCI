using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCI.Core.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCI.WebAPI.Controllers {
    public class CompanyController : Controller {
        
        [Authorize(Roles = Roles.COMPANY)]
        [HttpPost("setStandards")]
        public IActionResult SetStandards() {

        }
    }
}

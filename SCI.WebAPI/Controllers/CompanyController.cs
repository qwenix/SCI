using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCI.Core.Constants;
using SCI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCI.WebAPI.Controllers {

    [ApiController]
    [Route("[controller]")]
    public class CompanyController : Controller {
        


        [HttpPost("edit")]
        public Task<IActionResult> EditCompany(Company company) {

        }

    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCI.Core.Constants;
using SCI.Core.Entities;
using SCI.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCI.WebAPI.Controllers {

    [ApiController]
    [Route("[controller]")]
    public class CompanyController : Controller {

        private readonly ICompanyRepository companyRepository;

        public CompanyController(ICompanyRepository companyRepository) {
            this.companyRepository = companyRepository;
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateCompany([FromBody] Company company) {
            companyRepository.Update(company);
            await companyRepository.SaveChangesAsync();
            return Ok(company);
        }
    }
}

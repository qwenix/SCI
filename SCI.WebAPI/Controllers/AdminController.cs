using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCI.Core.Constants;
using SCI.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCI.WebAPI.Controllers {

    [ApiController]
    [Authorize(Roles = Roles.GOD + "," + Roles.ADMIN)]
    [Route("[controller]")]
    public class AdminController : Controller {

        private readonly IAdminService dataManager;

        public AdminController(IAdminService dataManager) {
            this.dataManager = dataManager;
        }
        
        [HttpPost("backup")]
        public async Task<IActionResult> BackupDatabase(string path) {
            await dataManager.BackupDatabase(path);
            return Ok();
        }

    }
}

using Microsoft.AspNetCore.Identity;
using SCI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Core.Interfaces.Services {

    public interface IUserService {

        Task DeleteUserAsync(string username);
        Task DeleteCompanyAdminAsync(string username);
        Task DeleteAdminAsync(string username);

    }

}

using SCI.Core.Entities;
using SCI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Core.Interfaces.Services {
    public interface IDriverService {
        Task<DriverRidesReview> GetReviewAsync(string username, int? daysPeriod);
        Task<Driver> GetByUsernameAsync(string username);
    }
}

using SCI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Core.Interfaces.Services {
    public interface IDriverService {
        Task<DriverReview> GetDriverReview(string driverUsername, int daysPeriod);
    }
}

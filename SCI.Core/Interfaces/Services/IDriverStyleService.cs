using SCI.Core.Entities;
using SCI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Core.Interfaces.Services {
    public interface IDriverStyleService {
        Task<DriverStyleReview> GetDriverStyleReview(DriverRidesReview driverRidesReview);
    }
}

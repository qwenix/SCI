using SCI.Core.Entities;
using SCI.Core.Interfaces.Repositories;
using SCI.Core.Interfaces.Services;
using SCI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Services {
    public class DriverService : IDriverService {

        private readonly IDriverRepository driverRepository;

        public DriverService(IDriverRepository driverRepository) {
            this.driverRepository = driverRepository;
        }

        public async Task<DriverReview> GetDriverReview(string driverUsername, int daysPeriod) {
            Driver driver = await driverRepository.GetByUsernameWithRides(driverUsername);

        }
    }
}

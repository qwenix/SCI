using AutoMapper;
using SCI.Core.Entities;
using SCI.Core.Extensions;
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
        private readonly IMapper mapper;

        public DriverService(IDriverRepository driverRepository, IMapper mapper) {
            this.driverRepository = driverRepository;
            this.mapper = mapper;
        }

        public async Task<DriverReview> GetDriverReview(string driverUsername, int daysPeriod) {
            Driver driver = await driverRepository.GetByUsernameWithRides(driverUsername);
            IEnumerable<Ride> rides = driver.GetLastRides(daysPeriod);
            var driverReview = mapper.Map<DriverReview>(rides);
            driverReview.DaysPeriod = daysPeriod;
            return driverReview;
        }
    }
}

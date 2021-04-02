using AutoMapper;
using Microsoft.Extensions.Configuration;
using SCI.Core.Constants;
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

        private readonly int maxDaysPeriod;

        public DriverService(IDriverRepository driverRepository, IMapper mapper,
            IConfiguration configuration) {
            this.driverRepository = driverRepository;
            this.mapper = mapper;
            maxDaysPeriod = configuration.GetValue<int>(AppSettingsStrings.MAX_DAYS_PERIOD);
        }

        public async Task<Driver> GetByUsernameAsync(string username) {
            return await driverRepository.GetByUsername(username);
        }

        public async Task<DriverRidesReview> GetReviewAsync(string username, int? daysPeriod) {
            int days = daysPeriod ?? maxDaysPeriod;
            if (days > maxDaysPeriod) {
                days = maxDaysPeriod;
            }

            Driver driver = await driverRepository.GetByUsernameWithRides(username); 
            IEnumerable<Ride> rides = driver.GetLastRides(days);
            var driverReview = mapper.Map<DriverRidesReview>(rides);
            driverReview.DaysPeriod = days;
            driverReview.DriverUsername = username;
            return driverReview;
        }
    }
}

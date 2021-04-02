using AutoMapper;
using Microsoft.Extensions.Configuration;
using SCI.Core.Attributes;
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
    public class DriverStyleService : IDriverStyleService {

        private readonly IDriverRepository driverRepository;
        private readonly IConvolutionService convolutionService;
        private readonly IMapper mapper;

        private readonly int maxDaysPeriod;
        private readonly int rateScaleMaximum;

        public DriverStyleService(IDriverRepository driverRepository, IMapper mapper,
            IConfiguration configuration, IConvolutionService convolutionService) {
            this.driverRepository = driverRepository;
            this.convolutionService = convolutionService;
            this.mapper = mapper;
            maxDaysPeriod = configuration.GetValue<int>(AppSettingsStrings.MAX_DAYS_PERIOD);
            rateScaleMaximum = configuration.GetValue<int>(AppSettingsStrings.RATE_SCALE_MAXIMUM);
        }

        public async Task<Driver> GetByUsernameAsync(string username) {
            return await driverRepository.GetByUsername(username);
        }

        public async Task<DriverStyleReview> GetDriverStyleReview(DriverRidesReview driverRidesReview) {
            Driver driver = await driverRepository.GetByUsernameWithCompany(driverRidesReview.DriverUsername);
            DriverStyleReview driverStyleReview = driverRidesReview
                .GetPerUnitDriverRidesReview(driver.Company.MileageUnit)
                .GetDriverStyleReview(driver.Company, rateScaleMaximum);

            List<KeyValuePair<int, double>> ratesPriorities = 
                GetRatesPriorities(driverStyleReview, driver.Company);

            
            driverStyleReview.TotalScore = convolutionService
                .CountConvolution(ratesPriorities.ToRatesWeightsList());

            return driverStyleReview;
        }

        private List<KeyValuePair<int, double>> GetRatesPriorities(
            DriverStyleReview driverStyleReview, Company company) {

            List<KeyValuePair<int, double>> ratesPriorities = new();

            foreach (var property in company.GetType().GetProperties()) {
                object[] attributes = property.GetCustomAttributes(false);
                if (attributes.Any(a => a is PriorityPropertyAttribute)) {
                    string name = property.Name.ToRatePropertyName();
                    int priority = Convert.ToInt32(property
                        .GetValue(company));
                    double rate = Convert.ToDouble(driverStyleReview
                        .GetType()
                        .GetProperty(name.ToRatePropertyName())
                        .GetValue(driverStyleReview));

                    ratesPriorities.Add(new KeyValuePair<int, double>(priority, rate));
                }
            }

            return ratesPriorities;
        }
    }
}

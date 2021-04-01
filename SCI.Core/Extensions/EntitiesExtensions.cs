using SCI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Core.Extensions {
    public static class EntitiesExtensions {

        public static ApplicationUser SetId(this ApplicationUser applicationUser) {
            applicationUser.Id = applicationUser.User.Id;
            return applicationUser;
        }

        public static Company SetId(this Company company) {
            company.Id = company.User.Id;
            return company;
        }

        public static Driver SetId(this Driver driver) {
            driver.Id = driver.ApplicationUser.Id = driver.ApplicationUser.User.Id;
            return driver;
        }

    }
}

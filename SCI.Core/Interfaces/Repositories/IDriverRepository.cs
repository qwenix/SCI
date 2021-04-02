﻿using Microsoft.AspNetCore.Identity;
using SCI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Core.Interfaces.Repositories {
    public interface IDriverRepository : IBaseRepository {
        Task AddAsync(Driver driver);
        Task<Driver> GetByUsernameWithRides(string username);
        Task<Driver> GetByUsername(string username);
        Task<Driver> GetByUsernameWithCompany(string username);
    }
}

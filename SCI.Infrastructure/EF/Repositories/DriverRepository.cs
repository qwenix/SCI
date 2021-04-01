using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
using SCI.Core.Entities;
using SCI.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace SCI.Infrastructure.EF.Repositories {
    public class DriverRepository : BaseRepository, IDriverRepository {

        public DriverRepository(DbContext context) : base(context) { }

        public async Task AddAsync(Driver driver) {
            await dbContext.Set<Driver>().AddAsync(driver);
        }
    }
}

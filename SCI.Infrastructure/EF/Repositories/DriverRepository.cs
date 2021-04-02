using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
using SCI.Core.Constants;
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

        private readonly IUserRepository userRepository;

        public DriverRepository(DbContext context, IUserRepository userRepository) : 
            base(context) {
            this.userRepository = userRepository;
        }

        public async Task AddAsync(Driver driver) {
            await dbContext.Set<Driver>().AddAsync(driver);
        }

        public async Task<Driver> GetByUsername(string username) {
            User user = await GetUserIfInRoleAsync(username, Roles.DRIVER);
            return await dbContext.Set<Driver>().FirstAsync(d => d.Id == user.Id);
        }

        public async Task<Driver> GetByUsernameWithRides(string username) {
            User user = await GetUserIfInRoleAsync(username, Roles.DRIVER);
            return await dbContext
                .Set<Driver>()
                .Include(d => d.Rides)
                .FirstAsync(d => d.Id == user.Id);
        }

        private async Task<User> GetUserIfInRoleAsync(string username, string roleName) {
            User user = await userRepository.FindByUsernameIfInRoleAsync(username, Roles.DRIVER);
            if (user is null) {
                throw new Exception("User is not Driver!");
            }
            return user;
        }
    }
}

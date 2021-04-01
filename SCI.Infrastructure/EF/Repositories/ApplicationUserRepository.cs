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
    public class ApplicationUserRepository : BaseRepository, IApplicationUserRepository {

        public ApplicationUserRepository(DbContext context) : base(context) { }

        public async Task AddAsync(ApplicationUser user) {
            await dbContext.Set<ApplicationUser>().AddAsync(user);
        }
    }
}

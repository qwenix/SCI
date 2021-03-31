using AutoMapper;
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
    public class UserRepository : IUserRepository {

        protected readonly DbContext dbContext;
        protected readonly IMapper mapper;

        public UserRepository(DbContext dbContext, IMapper mapper) {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<User> FirstIncludedAsync(Expression<Func<User, bool>> predicate) {
            return await dbContext.Set<User>()
                .Include(x => x.Role)
                .FirstAsync(predicate);
        }

        public virtual async Task<IEnumerable<User>> GetAllAsync() {
            return await dbContext.Set<User>().ToListAsync();
        }

        public virtual IEnumerable<User> GetAll() {
            return dbContext.Set<User>().ToList();
        }
    }
}

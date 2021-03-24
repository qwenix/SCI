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
    class UserRepository : DataAccessRepository<User>, IUserRepository {
        public UserRepository(DbContext dbContext, IMapper mapper) : base(dbContext, mapper) {

        }

        public async Task<User> FirstIncludedAsync(Expression<Func<User, bool>> predicate) {
            return await dbContext.Set<User>().Include(x => x.Role).FirstAsync(predicate);
        }
    }
}

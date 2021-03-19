using SCI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Core.Interfaces.Repositories {
    public interface IUserRepository {
        public Task<User> FirstIncludedAsync(Expression<Func<User, bool>> predicate);
    }
}

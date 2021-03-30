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
    class RoleRepository : IRoleRepository {

        protected readonly DbContext dbContext;
        protected readonly IMapper mapper;

        public RoleRepository(DbContext dbContext, IMapper mapper) {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public virtual async Task<IEnumerable<Role>> GetAllAsync() {
            return await dbContext.Set<Role>().ToListAsync();
        }

        public virtual IEnumerable<Role> GetAll() {
            return dbContext.Set<Role>().ToList();
        }
    }
}

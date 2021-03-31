using Microsoft.EntityFrameworkCore;
using SCI.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Infrastructure.EF.Repositories {
    public abstract class BaseRepository : IBaseRepository {

        protected readonly DbContext dbContext;

        protected BaseRepository(DbContext dbContext) {
            this.dbContext = dbContext;
        }

        public async Task SaveChangesAsync() {
            await dbContext.SaveChangesAsync();
        }
    }
}

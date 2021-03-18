using Microsoft.EntityFrameworkCore;
using SCI.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Infrastructure.EF {
    public class SciContext : DbContext {

        public DbSet<User> Users { get; set; }

        public SciContext(DbContextOptions<SciContext> options) : base (options) {

        }

        public async Task<int> SaveChangesAsync() {
            return await base.SaveChangesAsync();
        }
    }
}

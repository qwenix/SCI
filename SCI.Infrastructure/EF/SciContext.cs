using Microsoft.EntityFrameworkCore;
using SCI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Infrastructure.EF {
    class SciContext : DbContext {

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public SciContext(DbContextOptions<SciContext> options) : base(options) {
            Database.EnsureCreated();
        }
    }
}
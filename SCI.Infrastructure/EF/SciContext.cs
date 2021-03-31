using SCI.Core.Entities;
using System.Threading;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SCI.Infrastructure.EF {

    public class SciContext : IdentityDbContext<User> {

        public DbSet<Company> Companies { get; set; }

        public SciContext() { }

        public SciContext(DbContextOptions<SciContext> options) : base(options) {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);
            builder.Entity<Company>(entity => {
                entity.HasKey(e => e.UserId);
                entity.HasOne(e => e.User)
                    .WithOne(u => u.Company)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
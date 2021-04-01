using SCI.Core.Entities;
using System.Threading;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace SCI.Infrastructure.EF {

    public class SciContext : IdentityDbContext<User> {

        public DbSet<Company> Companies { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Driver> Drivers { get; set; }

        public SciContext() { }

        public SciContext(DbContextOptions<SciContext> options) : base(options) {
            ChangeTracker.AutoDetectChangesEnabled = false;

            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);

            builder.Entity<Company>(entity => {
                entity.HasKey(e => e.Id);
            });

            builder.Entity<User>(entity => {
                entity.HasOne(e => e.Company)
                    .WithOne(c => c.User)
                    .HasForeignKey<Company>(c => c.Id)
                    .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(e => e.ApplicationUser)
                    .WithOne(c => c.User)
                    .HasForeignKey<ApplicationUser>(ai => ai.Id)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<ApplicationUser>(entity => {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.Driver)
                    .WithOne(e => e.ApplicationUser)
                    .HasForeignKey<Driver>(d => d.Id)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<Driver>(entity => {
                entity.HasKey(e => e.Id);
            });
        }
    }
}
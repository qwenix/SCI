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
using SCI.Core.Entities.Events;

namespace SCI.Infrastructure.EF {

    public class SciContext : IdentityDbContext<User, IdentityRole<int>, int> {

        public DbSet<Company> Companies { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Ride> Rides { get; set; }

        public DbSet<EngineOffEvent> EngineOffEvents { get; set; }
        public DbSet<EngineOnEvent> EngineOnEvents { get; set; }
        public DbSet<EquipmentInstallEvent> EquipmentInstallEvents { get; set; }
        public DbSet<PhoneFreeEvent> PhoneFreeEvents { get; set; }
        public DbSet<PhoneUseEvent> PhoneUseEvents { get; set; }
        public DbSet<SlowDownEvent> SlowDownEvents { get; set; }
        public DbSet<SpeedUpEvent> SpeedUpEvents { get; set; }
        public DbSet<SpeedChangeEvent> SpeedChangeEvents { get; set; }
        public DbSet<SteeringWheelEvent> SteeringWheelEvents { get; set; }
        public DbSet<TurnEntryEvent> TurnEntryEvents { get; set; }

        public SciContext() { }

        public SciContext(DbContextOptions<SciContext> options) : base(options) {
            ChangeTracker.AutoDetectChangesEnabled = false;

            //Database.EnsureDeleted();
            //SaveChanges();
            //throw new Exception("Done");

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
                entity.HasOne(e => e.Company)
                    .WithMany(c => c.Drivers)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            builder.Entity<EngineOffEvent>(entity => {
                entity.HasKey(e => new { e.DateTime, e.DriverId });
            });

            builder.Entity<EngineOnEvent>(entity => {
                entity.HasKey(e => new { e.DateTime, e.DriverId });
            });

            builder.Entity<EquipmentInstallEvent>(entity => {
                entity.HasKey(e => new { e.DateTime, e.DriverId });
            });

            builder.Entity<PhoneFreeEvent>(entity => {
                entity.HasKey(e => new { e.DateTime, e.DriverId });
            });

            builder.Entity<PhoneUseEvent>(entity => {
                entity.HasKey(e => new { e.DateTime, e.DriverId });
            });

            builder.Entity<SlowDownEvent>(entity => {
                entity.HasKey(e => new { e.DateTime, e.DriverId });
            });

            builder.Entity<SpeedChangeEvent>(entity => {
                entity.HasKey(e => new { e.DateTime, e.DriverId });
            });

            builder.Entity<SpeedUpEvent>(entity => {
                entity.HasKey(e => new { e.DateTime, e.DriverId });
            });

            builder.Entity<SteeringWheelEvent>(entity => {
                entity.HasKey(e => new { e.DateTime, e.DriverId });
            });

            builder.Entity<TurnEntryEvent>(entity => {
                entity.HasKey(e => new { e.DateTime, e.DriverId });
            });

            builder.Entity<Ride>(entity => {
                entity.HasKey(e => new { e.StartDate, e.DriverId });
            });
        }
    }
}
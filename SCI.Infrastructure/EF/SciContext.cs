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

        public SciContext() { }

        public SciContext(DbContextOptions<SciContext> options) : base(options) {
            Database.EnsureCreated();
        }
    }
}
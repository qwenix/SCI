using Microsoft.EntityFrameworkCore;
using SCI.Core.Entities;
using SCI.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Infrastructure.EF.Repositories {
    public class RideRepository : BaseRepository, IRideRepository {

        public RideRepository(DbContext context) : base(context) { }

        public async Task AddAsync(Ride ride) {
            await dbContext.AddAsync(ride);
        }
    }
}

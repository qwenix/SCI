using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SCI.Core.DTOs;
using SCI.Core.Entities;
using SCI.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Infrastructure.Repositories.EF {
    public class EfRoleRepository : EfRepository<Role> {

        public EfRoleRepository(DbContext dbContext, IMapper mapper) : base(dbContext, mapper) {

        }

    }
}

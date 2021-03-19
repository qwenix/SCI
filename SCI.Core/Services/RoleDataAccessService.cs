using SCI.Core.DTOs;
using SCI.Core.Entities;
using SCI.Core.Interfaces.Repositories;
using SCI.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Core.Services {
    class RoleDataAccessService : DataAccessService<Role> {

        public RoleDataAccessService(IDataAccessRepository<Role> dataAccessRepository)
            : base (dataAccessRepository) { }
    }
}

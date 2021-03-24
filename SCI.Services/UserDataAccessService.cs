using SCI.Core.Entities;
using SCI.Core.Interfaces.Repositories;
using SCI.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Services {
    class UserDataAccessService : DataAccessService<User> {

        public UserDataAccessService(IDataAccessRepository<User> dataAccessRepository)
            : base (dataAccessRepository) { }
    }
}

using SCI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Core.Interfaces.Repositories {
    public interface IRoleRepository {
        public Task<IEnumerable<Role>> GetAllAsync();
        public IEnumerable<Role> GetAll();
    }
}

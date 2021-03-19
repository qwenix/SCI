using SCI.Core.DTOs;
using SCI.Core.Entities;
using SCI.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Core.Interfaces.Services {
    public abstract class DataAccessService<T> where T : BaseEntity, IFullAccess {

        private readonly IDataAccessRepository<T> dataAccessRepository;

        public DataAccessService(IDataAccessRepository<T> dataAccessRepository) {
            this.dataAccessRepository = dataAccessRepository;
        }

        public virtual T GetById(int id) {
            throw new NotImplementedException();
        }

        public virtual Task<T> GetByIdAsync(int id) {
            throw new NotImplementedException();
        }

        public virtual Task<IEnumerable<T>> GetAllAsync() {
            throw new NotImplementedException();
        }

        public virtual Task<T> AddAsync(T dto) {
            throw new NotImplementedException();
        }

        public virtual Task UpdateAsync(T dto) {
            throw new NotImplementedException();
        }

        public virtual Task DeleteAsync(T dto) {
            throw new NotImplementedException();
        }
    }
}

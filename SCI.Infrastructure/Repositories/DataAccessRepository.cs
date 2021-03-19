using Microsoft.EntityFrameworkCore;
using SCI.Core.Entities;
using SCI.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Infrastructure.Repositories {
    class DataAccessRepository : IDataAccessRepository {
        
        public Task<T> AddAsync<T>(T entity) where T : BaseEntity {
            throw new NotImplementedException();
        }

        public Task DeleteAsync<T>(T entity) where T : BaseEntity {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> EnumerableAsync<T>() where T : BaseEntity {
            throw new NotImplementedException();
        }

        public T GetById<T>(int id) where T : BaseEntity {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync<T>(int id) where T : BaseEntity {
            throw new NotImplementedException();
        }

        public Task UpdateAsync<T>(T entity) where T : BaseEntity {
            throw new NotImplementedException();
        }
    }
}

using SCI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Core.Interfaces.Repositories {
    public interface IDataAccessRepository<T> where T : BaseEntity, IFullAccess {

        public T GetById(int id);
        public Task<T> GetByIdAsync(int id);
        public Task<IEnumerable<T>> GetAllAsync();
        public IEnumerable<T> GetAll();
        public Task<T> AddAsync(T dto);
        public Task UpdateAsync(T dto);
        public Task DeleteAsync(T dto);
    }
}

using SCI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Core.Interfaces.Services {
    public interface IDataAccessService<T> where T : BaseEntity, IFullAccess {

        public T GetById(int id);
        public Task<T> GetByIdAsync(int id);
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> AddAsync(T dto);
        public Task UpdateAsync(T dto);
        public Task DeleteAsync(T dto);
    }
}

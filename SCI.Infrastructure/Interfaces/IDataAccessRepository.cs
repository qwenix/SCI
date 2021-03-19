using SCI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Infrastructure.Interfaces {
    public interface IDataAccessRepository {

        T GetById<T>(int id) where T : BaseEntity;

        Task<T> GetByIdAsync<T>(int id) where T : BaseEntity;

        Task<IEnumerable<T>> EnumerableAsync<T>() where T : BaseEntity;

        Task<T> AddAsync<T>(T entity) where T : BaseEntity;

        Task UpdateAsync<T>(T entity) where T : BaseEntity;

        Task DeleteAsync<T>(T entity) where T : BaseEntity;
    }
}

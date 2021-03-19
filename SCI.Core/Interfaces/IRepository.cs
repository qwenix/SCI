using SCI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Core.Interfaces {
    public interface IRepository<T> where T : BaseEntity {

        IEnumerable<T> GetAll();
        Task<T> GetById(int id);
        Task<int> Add(T entity);
    }
}

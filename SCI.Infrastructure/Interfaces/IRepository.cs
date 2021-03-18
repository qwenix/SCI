using SCI.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Interfaces {
    public interface IRepository<T> where T : BaseEntity {

        IEnumerable<T> GetAll();
        T GetById(int id);
        Task<int> Add(T entity);
    }
}

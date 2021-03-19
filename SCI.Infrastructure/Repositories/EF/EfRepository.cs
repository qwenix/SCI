using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SCI.Core.DTOs;
using SCI.Core.Entities;
using SCI.Core.Interfaces;
using SCI.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Infrastructure.Repositories.EF {
    public abstract class EfRepository<T> : IDataAccessRepository<T> 
        where T : BaseEntity, IFullAccess {

        private readonly DbContext dbContext;
        private readonly IMapper mapper;

        public EfRepository(DbContext dbContext, IMapper mapper) {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public virtual T GetById(int id) {
            throw new NotImplementedException();
        }

        public virtual Task<T> GetByIdAsync(int id) {
            throw new NotImplementedException();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync() {
            return await dbContext.Set<T>().ToListAsync();
        }

        public virtual IEnumerable<T> GetAll() {
            return dbContext.Set<T>().ToList();
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

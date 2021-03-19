using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SCI.CrosscuttingConcerns.Logger;
using SCI.Infrastructure.EF;
using SCI.Infrastructure.Entities;
using SCI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Infrastructure.Repositories {
    public class UsersRepository<T> : IRepository<T> where T : BaseEntity {
        
        private readonly SciContext context;
        private readonly ILogger<UsersRepository<T>> logger;

        public UsersRepository(SciContext context, ILogger<UsersRepository<T>> logger) {
            this.context = context;
            this.logger = logger;
        }

        public IEnumerable<T> GetAll() {
            return context.Set<T>();
        }

        public async Task<T> GetById(int id) {
            return await context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> Add(T entity) {
            var result = await context.Set<T>().AddAsync(entity);
            if (result == null) {
                logger.LogWarning(LoggerStrings.ADDING_ERROR, entity);
            }
            await context.SaveChangesAsync();
            return result.Entity.Id;
        }
    }
}

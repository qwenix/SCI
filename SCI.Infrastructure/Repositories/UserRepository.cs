using SCI.Infrastructure.EF;
using SCI.Infrastructure.Entities;
using SCI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Infrastructure.Repositories {
    public class UserRepository<T> : IRepository<T> where T : BaseEntity {
        
        private readonly SciContext context;

        public UserRepository(SciContext context) {
            this.context = context;
        }

        public IEnumerable<T> GetAll() {
            return context.Set<T>();
        }

        public T GetById(int id) {
            var result = context.Set<T>().FirstOrDefault(x => x.Id == id);

            if (result == null) {
                //todo: need to add logger
                return null;
            }

            return result;
        }

        public async Task<int> Add(T entity) {
            var result = await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
            return result.Entity.Id;
        }
    }
}

using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
using SCI.Core.Entities;
using SCI.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace SCI.Infrastructure.EF.Repositories {
    public class CompanyRepository : ICompanyRepository {

        private readonly DbContext context;

        public CompanyRepository(DbContext context) {
            this.context = context;
        }

        public async Task AddAsync(Company company) {
            await context.Set<Company>().AddAsync(company);
        }
    }
}

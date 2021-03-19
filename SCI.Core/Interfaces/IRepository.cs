﻿using SCI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCI.Core.Interfaces {
    public interface IRepository<T> where T : BaseEntity {

        T GetById<T>(int id) where T : BaseEntity;

        Task<T> GetByIdAsync<T>(int id) where T : BaseEntity;

        Task<IEnumerable<T>> EnumerableAsync<T>() where T : BaseEntity;

        Task<T> AddAsync<T>(T entity) where T : BaseEntity;

        Task UpdateAsync<T>(T entity) where T : BaseEntity;

        Task DeleteAsync<T>(T entity) where T : BaseEntity;


        IEnumerable<T> GetAll();
        Task<T> GetById(int id);
        Task<int> Add(T entity);
    }
}

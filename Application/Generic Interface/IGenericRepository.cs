﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Generic_Interface
{
    public interface IGenericRepository<T>
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(Guid id);
        Task UpdateIsDeletedFlag(Guid id);
        Task<T> GetByNameAsync(string name);
    }
}

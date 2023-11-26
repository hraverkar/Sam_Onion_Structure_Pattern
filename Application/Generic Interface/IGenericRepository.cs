﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace saloon_web.Generic_Interface
{
    public interface IGenericRepository<T>
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
    }
}

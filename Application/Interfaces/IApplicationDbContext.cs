using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<User> Users { get; set; }
        Task<int> SaveChangesAsync();
        //Task<IEnumerable<T>> GetAll();
        //Task<T> GetById(Guid id);
        //Task Add(T entity);
        //Task Update(T entity);
        //Task Delete(Guid id);
    }
}

using Application.Generic_Interface;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    internal class GradeRepository(IApplicationDbContext context) : IGenericRepository<Grade>
    {
        private readonly IApplicationDbContext _context = context;

        public async Task AddAsync(Grade entity)
        {
            _context.Grades.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Grade>> GetAllAsync()
        {
            return await _context.Grades.ToListAsync();
        }

        public async Task<Grade> GetByIdAsync(Guid id)
        {
            return await _context.Grades.FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task UpdateIsDeletedFlag(Guid id)
        {
            throw new NotImplementedException();
        }

        async Task IGenericRepository<Grade>.DeleteAsync(Guid id)
        {
            var user = await _context.Grades.FirstOrDefaultAsync(c => c.Id == id);
            if (user != null)
            {
                _context.Grades.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        Task<Grade> IGenericRepository<Grade>.GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        async Task IGenericRepository<Grade>.UpdateAsync(Grade entity)
        {
            var user = await _context.Grades.FirstOrDefaultAsync(c => c.Id == entity.Id);
            if (user != null)
            {
                _context.Grades.Update(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
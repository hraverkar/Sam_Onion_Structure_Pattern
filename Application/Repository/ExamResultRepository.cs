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
    internal class ExamResultRepository(IApplicationDbContext context) : IGenericRepository<ExamResult>
    {
        private readonly IApplicationDbContext _context = context;

        public async Task AddAsync(ExamResult entity)
        {
            _context.ExamResults.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ExamResult>> GetAllAsync()
        {
            return await _context.ExamResults.ToListAsync();
        }

        public async Task<ExamResult> GetByIdAsync(Guid id)
        {
            return await _context.ExamResults.FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task UpdateIsDeletedFlag(Guid id)
        {
            throw new NotImplementedException();
        }

        async Task IGenericRepository<ExamResult>.DeleteAsync(Guid id)
        {
            var user = await _context.ExamResults.FirstOrDefaultAsync(c => c.Id == id);
            if (user != null)
            {
                _context.ExamResults.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        Task<ExamResult> IGenericRepository<ExamResult>.GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        async Task IGenericRepository<ExamResult>.UpdateAsync(ExamResult entity)
        {
            var user = await _context.ExamResults.FirstOrDefaultAsync(c => c.Id == entity.Id);
            if (user != null)
            {
                _context.ExamResults.Update(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
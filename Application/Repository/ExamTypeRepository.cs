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
    internal class ExamTypeRepository : IGenericRepository<ExamType>
    {
        private readonly IApplicationDbContext _context;
        public ExamTypeRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ExamType entity)
        {
            _context.ExamTypes.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ExamType>> GetAllAsync()
        {
            return await _context.ExamTypes.ToListAsync();
        }

        public async Task<ExamType> GetByIdAsync(Guid id)
        {
            return await _context.ExamTypes.FirstOrDefaultAsync(c => c.Id == id);
        }

        async Task IGenericRepository<ExamType>.DeleteAsync(Guid id)
        {
            var user = await _context.ExamTypes.FirstOrDefaultAsync(c => c.Id == id);
            if (user != null)
            {
                _context.ExamTypes.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        async Task IGenericRepository<ExamType>.UpdateAsync(ExamType entity)
        {
            var user = await _context.ExamTypes.FirstOrDefaultAsync(c => c.Id == entity.Id);
            if (user != null)
            {
                _context.ExamTypes.Update(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
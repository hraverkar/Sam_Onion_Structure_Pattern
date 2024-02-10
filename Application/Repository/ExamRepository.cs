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
    internal class ExamRepository : IGenericRepository<Exam>
    {
        private readonly IApplicationDbContext _context;
        public ExamRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Exam entity)
        {
            _context.Exams.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Exam>> GetAllAsync()
        {
            return await _context.Exams.ToListAsync();
        }

        public async Task<Exam> GetByIdAsync(Guid id)
        {
            return await _context.Exams.FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task UpdateIsDeletedFlag(Guid id)
        {
            throw new NotImplementedException();
        }

        async Task IGenericRepository<Exam>.DeleteAsync(Guid id)
        {
            var user = await _context.Exams.FirstOrDefaultAsync(c => c.Id == id);
            if (user != null)
            {
                _context.Exams.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        async Task IGenericRepository<Exam>.UpdateAsync(Exam entity)
        {
            var user = await _context.Exams.FirstOrDefaultAsync(c => c.Id == entity.Id);
            if (user != null)
            {
                _context.Exams.Update(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
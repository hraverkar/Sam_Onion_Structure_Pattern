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
    internal class TeacherRepository : IGenericRepository<Teacher>
    {
        private readonly IApplicationDbContext _context;
        public TeacherRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Teacher entity)
        {
            _context.Teachers.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Teacher>> GetAllAsync()
        {
            return await _context.Teachers.ToListAsync();
        }

        public async Task<Teacher> GetByIdAsync(Guid id)
        {
            return await _context.Teachers.FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task UpdateIsDeletedFlag(Guid id)
        {
            throw new NotImplementedException();
        }

        async Task IGenericRepository<Teacher>.DeleteAsync(Guid id)
        {
            var user = await _context.Teachers.FirstOrDefaultAsync(c => c.Id == id);
            if (user != null)
            {
                _context.Teachers.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        async Task IGenericRepository<Teacher>.UpdateAsync(Teacher entity)
        {
            var user = await _context.Teachers.FirstOrDefaultAsync(c => c.Id == entity.Id);
            if (user != null)
            {
                _context.Teachers.Update(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
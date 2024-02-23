using Application.Generic_Interface;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class AttendanceRepository(IApplicationDbContext context) : IGenericRepository<Attendance>
    {
        private readonly IApplicationDbContext _context = context;

        public async Task AddAsync(Attendance entity)
        {
            _context.Attendances.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Attendance>> GetAllAsync()
        {
            return await _context.Attendances.ToListAsync();
        }

        public async Task<Attendance> GetByIdAsync(Guid id)
        {
            return await _context.Attendances.FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task UpdateIsDeletedFlag(Guid id)
        {
            throw new NotImplementedException();
        }

        async Task IGenericRepository<Attendance>.DeleteAsync(Guid id)
        {
            var user = await _context.Attendances.FirstOrDefaultAsync(c => c.Id == id);
            if (user != null)
            {
                _context.Attendances.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        Task<Attendance> IGenericRepository<Attendance>.GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        async Task IGenericRepository<Attendance>.UpdateAsync(Attendance entity)
        {
            var user = await _context.Attendances.FirstOrDefaultAsync(c => c.Id == entity.Id);
            if (user != null)
            {
                _context.Attendances.Update(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}

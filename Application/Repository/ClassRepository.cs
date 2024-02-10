using Application.Generic_Interface;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class ClassRepository : IGenericRepository<ClassTable>
    {
        private readonly IApplicationDbContext _context;
        public ClassRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ClassTable entity)
        {
            _context.Classes.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ClassTable>> GetAllAsync()
        {
            return await _context.Classes.ToListAsync();
        }

        public async Task<ClassTable> GetByIdAsync(Guid id)
        {
            return await _context.Classes.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateIsDeletedFlag(Guid id)
        {
            var user = await _context.Classes.FirstOrDefaultAsync(c => c.Id == id);
            if (user != null)
            {
                user.IsDeleted = true;
                user.UpdatedBy = "Harshal";
                user.UpdatedAt = DateTime.Now;
                _context.Classes.Update(user);
                await _context.SaveChangesAsync();
            }
        }

        async Task IGenericRepository<ClassTable>.DeleteAsync(Guid id)
        {
            var user = await _context.Files.FirstOrDefaultAsync(c => c.Id == id);
            if (user != null)
            {
                _context.Files.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        async Task IGenericRepository<ClassTable>.UpdateAsync(ClassTable entity)
        {
            var user = await _context.Files.FirstOrDefaultAsync(c => c.Id == entity.Id);
            if (user != null)
            {
                _context.Files.Update(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}

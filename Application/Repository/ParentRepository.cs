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
    internal class ParentRepository(IApplicationDbContext context) : IGenericRepository<Parent>
    {
        private readonly IApplicationDbContext _context = context;

        public async Task AddAsync(Parent entity)
        {
            _context.Parents.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Parent>> GetAllAsync()
        {
            return await _context.Parents.ToListAsync();
        }

        public async Task<Parent> GetByIdAsync(Guid id)
        {
            return await _context.Parents.FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task UpdateIsDeletedFlag(Guid id)
        {
            throw new NotImplementedException();
        }

        async Task IGenericRepository<Parent>.DeleteAsync(Guid id)
        {
            var user = await _context.Parents.FirstOrDefaultAsync(c => c.Id == id);
            if (user != null)
            {
                _context.Parents.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        async Task IGenericRepository<Parent>.UpdateAsync(Parent entity)
        {
            var user = await _context.Parents.FirstOrDefaultAsync(c => c.Id == entity.Id);
            if (user != null)
            {
                _context.Parents.Update(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
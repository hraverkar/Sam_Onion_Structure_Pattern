
using Application.Generic_Interface;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class UserRepository : IGenericRepository<User>
    {
        private readonly IApplicationDbContext _context;
        public UserRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User entity)
        {
            _context.Users.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(c => c.Id == id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            return await _context.Users.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateAsync(User entity)
        {
            var user = await _context.Users.FirstOrDefaultAsync(c => c.Id == entity.Id);
            if (user != null)
            {

                _context.Users.Update(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}

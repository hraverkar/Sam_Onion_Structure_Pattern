using Application.Generic_Interface;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class AuthorRepository(IApplicationDbContext context) : IGenericRepository<Author>
    {
        private readonly IApplicationDbContext _context = context;

        public async Task AddAsync(Author entity)
        {
            _context.Authors.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            return await _context.Authors.ToListAsync();
        }

        public async Task<Author> GetByIdAsync(Guid id)
        {
            return await _context.Authors.FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task UpdateIsDeletedFlag(Guid id)
        {
            var user = await _context.Authors.FirstOrDefaultAsync(c => c.Id == id);
            if (user != null)
            {
                user.IsDeleted = true;
                user.UpdatedBy = "Harshal";
                user.UpdatedAt = DateTime.Now;
                _context.Authors.Update(user);
                await _context.SaveChangesAsync();
            }
        }

        async Task IGenericRepository<Author>.DeleteAsync(Guid id)
        {
            var blogPost = await _context.Authors.FirstOrDefaultAsync(c => c.Id == id);
            if (blogPost != null)
            {
                _context.Authors.Remove(blogPost);
                await _context.SaveChangesAsync();
            }
        }

        async Task<Author> IGenericRepository<Author>.GetByNameAsync(string email)
        {
            return await _context.Authors.Where(r => !r.IsDeleted).FirstOrDefaultAsync(c => c.Email == email);
        }

        async Task IGenericRepository<Author>.UpdateAsync(Author entity)
        {
            var blogPost = await _context.Authors.FirstOrDefaultAsync(c => c.Id == entity.Id);
            if (blogPost != null)
            {
                _context.Authors.Update(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}

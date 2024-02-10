using Application.Generic_Interface;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class FileRepository : IGenericRepository<FileDetails>
    {
        private readonly IApplicationDbContext _context;
        public FileRepository(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(FileDetails entity)
        {
            _context.Files.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var user = await _context.Files.FirstOrDefaultAsync(c => c.Id == id);
            if (user != null)
            {
                _context.Files.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<FileDetails>> GetAllAsync()
        {
            return await _context.Files.ToListAsync();
        }

        public async Task<FileDetails> GetByIdAsync(Guid id)
        {
            return await _context.Files.FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task UpdateAsync(FileDetails entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateIsDeletedFlag(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

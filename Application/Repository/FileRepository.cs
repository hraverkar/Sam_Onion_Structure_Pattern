using Application.Interfaces;
using Domain.Entities;
using saloon_web.Generic_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<FileDetails>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<FileDetails> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(FileDetails entity)
        {
            throw new NotImplementedException();
        }
    }
}

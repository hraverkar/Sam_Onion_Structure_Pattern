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
    internal class StudentRepository : IGenericRepository<Student>
    {
        private readonly IApplicationDbContext _context;
        public StudentRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Student entity)
        {
            _context.Students.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student> GetByIdAsync(Guid id)
        {
            return await _context.Students.FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task UpdateIsDeletedFlag(Guid id)
        {
            throw new NotImplementedException();
        }

        async Task IGenericRepository<Student>.DeleteAsync(Guid id)
        {
            var user = await _context.Students.FirstOrDefaultAsync(c => c.Id == id);
            if (user != null)
            {
                _context.Students.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        async Task IGenericRepository<Student>.UpdateAsync(Student entity)
        {
            var user = await _context.Students.FirstOrDefaultAsync(c => c.Id == entity.Id);
            if (user != null)
            {
                _context.Students.Update(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
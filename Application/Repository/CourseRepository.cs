using Application.Generic_Interface;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Repository
{
    internal class CourseRepository : IGenericRepository<Course>
    {
        private readonly IApplicationDbContext _context;
        public CourseRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Course entity)
        {
            _context.Courses.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<Course> GetByIdAsync(Guid id)
        {
            return await _context.Courses.FirstOrDefaultAsync(c => c.Id == id);
        }

        async Task IGenericRepository<Course>.DeleteAsync(Guid id)
        {
            var user = await _context.Courses.FirstOrDefaultAsync(c => c.Id == id);
            if (user != null)
            {
                _context.Courses.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        async Task IGenericRepository<Course>.UpdateAsync(Course entity)
        {
            var user = await _context.Courses.FirstOrDefaultAsync(c => c.Id == entity.Id);
            if (user != null)
            {
                _context.Courses.Update(entity);
                await _context.SaveChangesAsync();
            }
        }

        Task IGenericRepository<Course>.UpdateIsDeletedFlag(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
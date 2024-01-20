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
    internal class ClassRoomStudentRepository : IGenericRepository<ClassRoomStudent>
    {
        private readonly IApplicationDbContext _context;
        public ClassRoomStudentRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ClassRoomStudent entity)
        {
            _context.ClassRoomStudents.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ClassRoomStudent>> GetAllAsync()
        {
            return await _context.ClassRoomStudents.ToListAsync();
        }

        public async Task<ClassRoomStudent> GetByIdAsync(Guid id)
        {
            return await _context.ClassRoomStudents.FirstOrDefaultAsync(c => c.Id == id);
        }

        async Task IGenericRepository<ClassRoomStudent>.DeleteAsync(Guid id)
        {
            var user = await _context.ClassRoomStudents.FirstOrDefaultAsync(c => c.Id == id);
            if (user != null)
            {
                _context.ClassRoomStudents.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        async Task IGenericRepository<ClassRoomStudent>.UpdateAsync(ClassRoomStudent entity)
        {
            var user = await _context.ClassRoomStudents.FirstOrDefaultAsync(c => c.Id == entity.Id);
            if (user != null)
            {
                _context.ClassRoomStudents.Update(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
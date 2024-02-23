using Application.Generic_Interface;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class ClassRoomRepository(IApplicationDbContext context) : IGenericRepository<ClassRoom>
    {
        private readonly IApplicationDbContext _context = context;

        public async Task AddAsync(ClassRoom entity)
        {
            _context.ClassRooms.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ClassRoom>> GetAllAsync()
        {
            return await _context.ClassRooms.ToListAsync();
        }

        public async Task<ClassRoom> GetByIdAsync(Guid id)
        {
            return await _context.ClassRooms.FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task UpdateIsDeletedFlag(Guid id)
        {
            throw new NotImplementedException();
        }

        async Task IGenericRepository<ClassRoom>.DeleteAsync(Guid id)
        {
            var user = await _context.ClassRooms.FirstOrDefaultAsync(c => c.Id == id);
            if (user != null)
            {
                _context.ClassRooms.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        Task<ClassRoom> IGenericRepository<ClassRoom>.GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        async Task IGenericRepository<ClassRoom>.UpdateAsync(ClassRoom entity)
        {
            var user = await _context.ClassRooms.FirstOrDefaultAsync(c => c.Id == entity.Id);
            if (user != null)
            {
                _context.ClassRooms.Update(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}

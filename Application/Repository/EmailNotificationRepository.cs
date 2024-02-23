using Application.Generic_Interface;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class EmailNotificationRepository(IApplicationDbContext context) : IGenericRepository<EmailNotification>
    {
        private readonly IApplicationDbContext _context = context;

        public async Task AddAsync(EmailNotification entity)
        {
            _context.EmailNotifications.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<EmailNotification>> GetAllAsync()
        {
            return await _context.EmailNotifications.ToListAsync();
        }

        public async Task<EmailNotification> GetByIdAsync(Guid id)
        {
            return await _context.EmailNotifications.FirstOrDefaultAsync(c => c.Id == id);
        }

        async Task IGenericRepository<EmailNotification>.DeleteAsync(Guid id)
        {
            var user = await _context.EmailNotifications.FirstOrDefaultAsync(c => c.Id == id);
            if (user != null)
            {
                _context.EmailNotifications.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        Task<EmailNotification> IGenericRepository<EmailNotification>.GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        async Task IGenericRepository<EmailNotification>.UpdateAsync(EmailNotification entity)
        {
            var user = await _context.EmailNotifications.FirstOrDefaultAsync(c => c.Id == entity.Id);
            if (user != null)
            {
                _context.EmailNotifications.Update(entity);
                await _context.SaveChangesAsync();
            }
        }

        Task IGenericRepository<EmailNotification>.UpdateIsDeletedFlag(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

using Domain.Dtos;
using Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface INotificationService
    {
        Task<bool> SendEmailToUserAsync(EmailNotificationDto emailNotification, CancellationToken ct = default);
    }
}

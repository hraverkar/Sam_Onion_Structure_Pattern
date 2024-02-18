using Application.Features.ProductFeatures.Commands;
using Application.Generic_Interface;
using Application.Interfaces;
using Domain.Entities;
using Domain.Helper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.CommandHandlers
{
    public class SendBulkEmailNotificationCommandHandler : IRequestHandler<SendBulkEmailNotificationCommand, string>
    {
        public readonly IGenericRepository<EmailNotification> _emailNotificationRepo;
        public readonly INotificationService _notificationService;
        public SendBulkEmailNotificationCommandHandler(IGenericRepository<EmailNotification> emailNotificationRepo, INotificationService notificationService)
        {
            _emailNotificationRepo = emailNotificationRepo;
            _notificationService = notificationService;
        }
        public async Task<string> Handle(SendBulkEmailNotificationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var fileRes = FileHelper.FileStringToBase(request.File);
                return "";
            }
            catch (Exception ex)
            {
                return await Task.FromResult($"File email sent!! \r\n {ex}");
            }
        }
    }
}

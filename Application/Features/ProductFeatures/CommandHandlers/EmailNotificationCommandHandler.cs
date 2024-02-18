using Application.Features.ProductFeatures.Commands;
using Application.Generic_Interface;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.CommandHandlers
{
    public class EmailNotificationCommandHandler : IRequestHandler<EmailNotificationCommand, string>
    {
        private readonly IGenericRepository<EmailNotification> _emailNotificationRepo;
        private readonly INotificationService _notificationService;
        public EmailNotificationCommandHandler(IGenericRepository<EmailNotification> emailNotificationRepo, INotificationService notificationService)
        {
            _emailNotificationRepo = emailNotificationRepo;
            _notificationService = notificationService;
        }

        public async Task<string> Handle(EmailNotificationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                bool isEmailSent = await _notificationService.SendEmailToUserAsync(request.EmailNotification, new CancellationToken());

                EmailNotification emailNotification = new EmailNotification()
                {
                    ToEmailUserName = request.EmailNotification.ToEmailUserName,
                    ToEmailAddress = request.EmailNotification.ToEmailAddress,
                    FromEmailUserName = request.EmailNotification.FromEmailUserName,
                    FromEmailAddress = request.EmailNotification.FromEmailAddress,
                    Subject = request.EmailNotification.Subject,
                    Body = request.EmailNotification.Body,
                    Attachment = request.EmailNotification.Attachment,
                    IsSuccessed = isEmailSent
                };
                await _emailNotificationRepo.AddAsync(emailNotification);
                return await Task.FromResult("Email Sent!!");
            }
            catch (Exception ex)
            {
                return await Task.FromResult($"Email Send failed!! \r\n {ex}");
            }
        }
    }
}

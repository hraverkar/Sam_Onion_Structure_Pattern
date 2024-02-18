using Application.Interfaces;
using Domain.Dtos;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using Persistence.Config;
using System;
using System.Threading;
using System.Threading.Tasks;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace Application.Services
{
    public class NotificationService : INotificationService
    {
        private readonly MailSettings _mailSettings;

        public NotificationService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }
        public async Task<bool> SendEmailToUserAsync(EmailNotificationDto emailNotification, CancellationToken ct)
        {
            try
            {
                var mail = new MimeMessage
                {
                    From = { new MailboxAddress(_mailSettings.DisplayName, _mailSettings.From) },
                    Sender = new MailboxAddress(_mailSettings.DisplayName, _mailSettings.From),
                    To = { new MailboxAddress(emailNotification.ToEmailUserName, emailNotification.ToEmailAddress) },
                    Subject = emailNotification.Subject
                };

                var body = new BodyBuilder { HtmlBody = emailNotification.Body };
                mail.Body = body.ToMessageBody();

                using var smtpClient = new SmtpClient();

                var secureSocketOptions = _mailSettings.UseSSL
                    ? SecureSocketOptions.SslOnConnect
                    : (_mailSettings.UseStartTls ? SecureSocketOptions.StartTls : SecureSocketOptions.Auto);

                await smtpClient.ConnectAsync(_mailSettings.Host, _mailSettings.Port, secureSocketOptions, ct);
                await smtpClient.AuthenticateAsync(_mailSettings.UserName, _mailSettings.Password, ct);
                await smtpClient.SendAsync(mail, ct);
                await smtpClient.DisconnectAsync(true, ct);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

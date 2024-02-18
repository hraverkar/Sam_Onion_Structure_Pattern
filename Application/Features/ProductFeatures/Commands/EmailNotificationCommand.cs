using Domain.Dtos;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Commands
{
    public class EmailNotificationCommand(EmailNotificationDto emailNotification) : IRequest<string>
    {
        public EmailNotificationDto EmailNotification { get; set; } = emailNotification;
    }
}

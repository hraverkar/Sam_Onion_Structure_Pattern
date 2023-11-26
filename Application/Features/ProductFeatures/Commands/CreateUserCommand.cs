using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Commands
{
    public class CreateUserCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }

        public CreateUserCommand(Guid id, string name, string email, DateTime createAt, string createdBy)
        {
            Id = id;
            Name = name;
            Email = email;
            CreatedAt = createAt;
            CreatedBy = createdBy;
        }

    }
}
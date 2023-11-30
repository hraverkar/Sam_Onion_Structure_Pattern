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
    public class CreateUserCommand : IRequest<string>
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public CreateUserCommand(string name, string email)
        {
            Name = name;
            Email = email;
        }

    }
}
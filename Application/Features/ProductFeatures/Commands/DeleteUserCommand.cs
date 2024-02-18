using MediatR;
using System;

namespace Application.Features.ProductFeatures.Commands
{
    public class DeleteUserCommand(Guid id) : IRequest<string>
    {
        public Guid Id { get; set; } = id;
    }
}

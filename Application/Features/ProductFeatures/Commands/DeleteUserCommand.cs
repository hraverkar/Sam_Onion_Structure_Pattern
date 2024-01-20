using MediatR;
using System;

namespace Application.Features.ProductFeatures.Commands
{
    public class DeleteUserCommand: IRequest<string>
    {
        public Guid Id { get; set; }
        public DeleteUserCommand(Guid id)
        {
            Id = id;
        }
    }
}

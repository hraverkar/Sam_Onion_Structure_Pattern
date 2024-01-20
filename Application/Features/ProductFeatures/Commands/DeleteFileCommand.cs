using MediatR;
using System;

namespace Application.Features.ProductFeatures.Commands
{
    public class DeleteFileCommand : IRequest<string>
    {
        public Guid Id { get; set; }
        public DeleteFileCommand(Guid id)
        {
            Id = id;
        }
    }
}

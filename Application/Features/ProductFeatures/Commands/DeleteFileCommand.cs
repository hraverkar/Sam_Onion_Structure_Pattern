using MediatR;
using System;

namespace Application.Features.ProductFeatures.Commands
{
    public class DeleteFileCommand(Guid id) : IRequest<string>
    {
        public Guid Id { get; set; } = id;
    }
}

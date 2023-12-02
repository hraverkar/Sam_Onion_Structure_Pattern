using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

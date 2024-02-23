using Application.Features.ProductFeatures.Commands;
using Domain.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.CommandHandlers
{
    public class CreateBlogPostCommandHandler : IRequestHandler<CreateBlogPostCommand, CreateBlogPostModelDto>
    {
        public CreateBlogPostCommandHandler() { }
        public async Task<CreateBlogPostModelDto> Handle(CreateBlogPostCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

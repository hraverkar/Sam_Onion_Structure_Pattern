using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Queries
{
    public class DeleteAuthorQuery : IRequest<string>
    {
        public Guid Id { get; set; }
        public DeleteAuthorQuery(Guid id)
        {
            Id = id;
        }
    }
}

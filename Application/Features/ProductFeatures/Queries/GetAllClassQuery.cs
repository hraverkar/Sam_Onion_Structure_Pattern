using Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace Application.Features.ProductFeatures.Queries
{
    public class GetAllClassQuery: IRequest<IEnumerable<ClassTable>>
    {
        public GetAllClassQuery() { }
    }
}

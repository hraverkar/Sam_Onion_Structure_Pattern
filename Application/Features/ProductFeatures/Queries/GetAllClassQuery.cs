using Domain.Dtos;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Queries
{
    public class GetAllClassQuery: IRequest<IEnumerable<ClassTable>>
    {
        public GetAllClassQuery() { }
    }
}

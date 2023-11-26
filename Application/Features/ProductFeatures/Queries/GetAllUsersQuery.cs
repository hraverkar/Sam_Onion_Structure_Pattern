using Domain.Dtos;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.ProductFeatures.Queries
{
    public class GetAllUsersQuery: IRequest<IEnumerable<User>>
    {
        public GetAllUsersQuery() { }

    }
}

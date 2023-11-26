using Application.Features.ProductFeatures.Queries;
using Domain.Dtos;
using Domain.Entities;
using MediatR;
using saloon_web.Generic_Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.QueryHandlers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<User>>
    {
        public readonly IGenericRepository<User> _userRepository;
        public GetAllUsersQueryHandler(IGenericRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            var allUsers = await _userRepository.GetAllAsync();
            return allUsers;
        }
    }
}

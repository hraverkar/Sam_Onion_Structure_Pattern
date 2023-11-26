using Application.Features.ProductFeatures.Commands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using saloon_web.Generic_Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Application.Features.ProductFeatures.CommandHandlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Unit>
    {
        private readonly IGenericRepository<User> _userRepository;
        public CreateUserCommandHandler(IGenericRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        async Task<Unit> IRequestHandler<CreateUserCommand, Unit>.Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var User = new User
            {
                Id = command.Id,
                Name = command.Name,
                Email = command.Email,
                CreatedAt = command.CreatedAt,
                CreatedBy = command.CreatedBy
            };
            await _userRepository.AddAsync(User);
            return await Task.FromResult(Unit.Value);
        }
    }
}

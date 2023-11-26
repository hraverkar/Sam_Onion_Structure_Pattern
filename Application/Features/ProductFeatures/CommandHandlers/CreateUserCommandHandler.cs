using Application.Features.ProductFeatures.Commands;
using Domain.Entities;
using MediatR;
using saloon_web.Generic_Interface;
using System.Threading;
using System.Threading.Tasks;

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

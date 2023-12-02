using Application.Features.ProductFeatures.Commands;
using Application.Generic_Interface;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.CommandHandlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string>
    {
        private readonly IGenericRepository<User> _userRepository;
        public CreateUserCommandHandler(IGenericRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        async Task<string> IRequestHandler<CreateUserCommand, string>.Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var User = new User
                {
                    Name = command.Name,
                    Email = command.Email,
                    CreatedBy = "Harshal"
                };
                await _userRepository.AddAsync(User);
                return await Task.FromResult("User successfully created!!");
            }
            catch (Exception ex)
            {
                return await Task.FromResult($"User creation failed!! \r\n {ex}");
            }
        }
    }
}

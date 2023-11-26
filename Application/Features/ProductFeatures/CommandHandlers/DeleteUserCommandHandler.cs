using Application.Features.ProductFeatures.Commands;
using Domain.Entities;
using MediatR;
using saloon_web.Generic_Interface;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.CommandHandlers
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, string>
    {
        private readonly IGenericRepository<User> _userRepository;
        public DeleteUserCommandHandler(IGenericRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<string> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return "User deletion failed!!";
            }

            await _userRepository.DeleteAsync(request.Id);
            return "User successfully deleted!!";
        }
    }
}

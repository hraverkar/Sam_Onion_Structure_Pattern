using Application.Features.ProductFeatures.Commands;
using Application.Generic_Interface;
using Domain.Entities;
using MediatR;
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
                return await Task.FromResult("User deletion failed!!");
            }

            await _userRepository.UpdateIsDeletedFlag(request.Id);
            return await Task.FromResult("User successfully deleted!!");
        }
    }
}

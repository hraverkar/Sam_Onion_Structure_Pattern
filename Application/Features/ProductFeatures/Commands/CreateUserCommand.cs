using MediatR;

namespace Application.Features.ProductFeatures.Commands
{
    public class CreateUserCommand(string name, string email) : IRequest<string>
    {
        public string Name { get; set; } = name;
        public string Email { get; set; } = email;
    }
}
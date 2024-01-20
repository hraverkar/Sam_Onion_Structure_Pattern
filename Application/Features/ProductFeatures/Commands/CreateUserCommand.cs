using MediatR;

namespace Application.Features.ProductFeatures.Commands
{
    public class CreateUserCommand : IRequest<string>
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public CreateUserCommand(string name, string email)
        {
            Name = name;
            Email = email;
        }

    }
}
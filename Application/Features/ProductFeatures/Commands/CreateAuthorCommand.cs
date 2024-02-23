using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Commands
{
    public class CreateAuthorCommand : IRequest<string>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }

        public CreateAuthorCommand(string name, string email, string description)
        {
            Name = name;
            Email = email;
            Description = description;
        }
    }
}

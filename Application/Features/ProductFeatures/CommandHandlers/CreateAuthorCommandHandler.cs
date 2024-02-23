using Application.Features.ProductFeatures.Commands;
using Application.Generic_Interface;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.CommandHandlers
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, string>
    {
        private readonly IGenericRepository<Author> _authorRepository;
        public CreateAuthorCommandHandler(IGenericRepository<Author> authorRepository)
        {
            _authorRepository = authorRepository;
        }
        public async Task<string> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(request);
                var author = await _authorRepository.GetByNameAsync(request.Email);
                if (author == null)
                {
                    var newAuthor = new Author()
                    {
                        Name = request.Name,
                        Email = request.Email,
                        Description = request.Description,
                        CreatedAt = DateTime.UtcNow,
                        CreatedBy = "Harshal Raverkar"
                    };
                    await _authorRepository.AddAsync(newAuthor);
                    return await Task.FromResult($"{newAuthor.Name} Author Successfully Added!!");
                }
                return await Task.FromResult($"Author Addition Failed!!");
            }
            catch (Exception)
            {
                throw new UnauthorizedAccessException();
            }
        }
    }
}

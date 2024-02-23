using Application.Features.ProductFeatures.Queries;
using Application.Generic_Interface;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.QueryHandlers
{
    internal class DeleteAuthorQueryHandler : IRequestHandler<DeleteAuthorQuery, string>
    {
        private readonly IGenericRepository<Author> _authorRepository;
        public DeleteAuthorQueryHandler(IGenericRepository<Author> authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<string> Handle(DeleteAuthorQuery request, CancellationToken cancellationToken)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(request);
                var author = await _authorRepository.GetByIdAsync(request.Id);
                if (author != null)
                {
                    await _authorRepository.UpdateIsDeletedFlag(request.Id); 
                    return await Task.FromResult($"{author.Name} Author Deleted Successfully!!");
                }
                return await Task.FromResult($"Author Deletion Failed!!");
            }
            catch (Exception)
            {
                throw new UnauthorizedAccessException();
            }
        }
    }
}

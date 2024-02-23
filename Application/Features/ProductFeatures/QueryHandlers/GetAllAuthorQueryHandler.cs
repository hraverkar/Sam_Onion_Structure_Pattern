using Application.Features.ProductFeatures.Queries;
using Application.Generic_Interface;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.QueryHandlers
{
    public class GetAllAuthorQueryHandler : IRequestHandler<GetAllAuthorQuery, IEnumerable<Author>>
    {
        private readonly IGenericRepository<Author> _authorRepository;
        public GetAllAuthorQueryHandler(IGenericRepository<Author> authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<IEnumerable<Author>> Handle(GetAllAuthorQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            var allAuthor = await _authorRepository.GetAllAsync();
            return allAuthor.Where(s => !s.IsDeleted).OrderByDescending(c => c.CreatedAt);
        }
    }
}

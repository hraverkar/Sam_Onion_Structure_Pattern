using Application.Features.ProductFeatures.Queries;
using Application.Generic_Interface;
using Domain.Dtos;
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
    internal class GetAllClassQueryHandler : IRequestHandler<GetAllClassQuery, IEnumerable<ClassTable>>
    {
        IGenericRepository<ClassTable> _classTableRepo;
        public GetAllClassQueryHandler(IGenericRepository<ClassTable> ClassTbaleRepo)
        {
            _classTableRepo = ClassTbaleRepo;
        }

        async Task<IEnumerable<ClassTable>> IRequestHandler<GetAllClassQuery, IEnumerable<ClassTable>>.Handle(GetAllClassQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            var allClass = await _classTableRepo.GetAllAsync();
            return allClass.OrderByDescending(c => c.CreatedAt);
        }
    }
}

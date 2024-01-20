using Application.Features.ProductFeatures.Commands;
using Application.Generic_Interface;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.CommandHandlers
{
    public class DeleteFileCommandHandler : IRequestHandler<DeleteFileCommand, string>
    {
        private readonly IGenericRepository<FileDetails> _fileRepository;
        public DeleteFileCommandHandler(IGenericRepository<FileDetails> fileRepository)
        {
            _fileRepository = fileRepository;
        }

        public async Task<string> Handle(DeleteFileCommand request, CancellationToken cancellationToken)
        {
            if (request.Id != Guid.Empty)
            {
                await _fileRepository.DeleteAsync(request.Id);
                return await Task.FromResult("File deleted!!!");
            }

            return await Task.FromResult("File deletion failed !!");
        }
    }
}

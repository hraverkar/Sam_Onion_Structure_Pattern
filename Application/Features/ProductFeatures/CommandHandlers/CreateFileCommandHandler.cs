using Application.Features.ProductFeatures.Commands;
using Application.Generic_Interface;
using Domain.Entities;
using Domain.Helper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.CommandHandlers
{
    public class CreateFileCommandHandler : IRequestHandler<CreateFileCommand, string>
    {
        private readonly IGenericRepository<FileDetails> _fileRepository;
        public CreateFileCommandHandler(IGenericRepository<FileDetails> fileRepository)
        {
            _fileRepository = fileRepository;
        }

        public async Task<string> Handle(CreateFileCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var fileRes = FileHelper.FileStringToBase(request.File);
                var fileDetail = new FileDetails
                {
                    FileData = fileRes,
                    FileName = request.FileName,
                    CreatedBy = "Harshal Raverkar"
                };

                await _fileRepository.AddAsync(fileDetail);
                return await Task.FromResult("File successfully saved!!");
            }
            catch (Exception ex)
            {
                return await Task.FromResult($"File saving failed!! \r\n {ex}");
            }
        }
    }
}

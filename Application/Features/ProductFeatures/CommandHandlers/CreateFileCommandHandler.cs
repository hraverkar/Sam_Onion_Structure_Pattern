using Application.Features.ProductFeatures.Commands;
using Application.Generic_Interface;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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
                var fileRes = FileStringToBase(request.File);
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

        private static byte[] FileStringToBase(string file)
        {
            var arrData = file.Split(';');
            if (arrData != null && arrData.Length > 1)
            {
                var base64Data = arrData[1].Split(',');
                if (base64Data != null && base64Data.Length > 0)
                {
                    return Convert.FromBase64String(base64Data[1]);
                }
            }
            return null;
        }
    }
}

﻿using MediatR;

namespace Application.Features.ProductFeatures.Commands
{
    public class CreateFileCommand(string fileName, string file, byte[] fileData) : IRequest<string>
    {
        public string FileName { get; set; } = fileName;
        public string File { get; set; } = file;
        public byte[] Content { get; set; } = fileData;
    }
}

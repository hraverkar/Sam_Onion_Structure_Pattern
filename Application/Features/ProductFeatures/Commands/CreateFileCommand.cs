using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Commands
{
    public class CreateFileCommand : IRequest<string>
    {
        public string FileName { get; set; }
        public string File { get; set; }
        public byte[] Content { get; set; }

        public CreateFileCommand(string fileName, string file, byte[] fileData)
        {
            FileName = fileName;
            File = file;
            Content = fileData;
        }
    }
}

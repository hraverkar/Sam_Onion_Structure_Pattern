using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Queries
{
    public class GetTemplateQuery : IRequest<byte[]>
    {
        public string FileName { get; set; }
        public GetTemplateQuery(string fileName)
        {
            FileName = fileName;
        }
    }
}

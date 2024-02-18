using Application.Features.ProductFeatures.Queries;
using MediatR;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.QueryHandlers
{
    public class GetTemplateQueryHandler : IRequestHandler<GetTemplateQuery, byte[]>
    {
        public readonly string assetFolderPath = $"../../../Assets/BulkEmailTemplate.xlsx";
        async Task<byte[]> IRequestHandler<GetTemplateQuery, byte[]>.Handle(GetTemplateQuery request, CancellationToken cancellationToken)
        {
            try
            {
                if (File.Exists(assetFolderPath))
                {
                    return await File.ReadAllBytesAsync(assetFolderPath, cancellationToken);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetTemplateQueryHandler: {ex.Message}");
                throw;
            }
        }
    }
}

using Application.Interfaces;
using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class BlobService : IBlobService
    {
        private string ConnectionString = "DefaultEndpointsProtocol=https;AccountName=schoolblogblobst;AccountKey=UgfmCHYD+m0YbOPrOcLAWzA8RwZ+67zi2CBlScciDAG+Ik33pjydyeOf5sn/1hxD0Hmu7cnNAsGy+AStmqCJew==;EndpointSuffix=core.windows.net";
        private string ContainerName = "school-information";
        public BlobService()
        {
        }

        public string SaveFileIntoBlob(string fileName, byte[] content)
        {
            try
            {
                var blobServiceClient = new BlobServiceClient(ConnectionString);
                var blobContainerClient = blobServiceClient.GetBlobContainerClient(ContainerName);
                // Ensure the container exists
                blobContainerClient.CreateIfNotExists();
                var blobClient = blobContainerClient.GetBlobClient(fileName);
                // Upload the content to blob storage
                using (var contentStream = new MemoryStream(content))
                {
                    blobClient.Upload(contentStream, overwrite: true);
                }
                return fileName;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving the file to Blob Storage: {ex.Message}");
                throw;
            }
        }
    }
}

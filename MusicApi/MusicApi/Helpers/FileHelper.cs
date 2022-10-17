using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using MusicApi.Models;
using System.IO;
using System.Threading.Tasks;

namespace MusicApi.Helpers
{
    public static class FileHelper
    {
        public static async Task<string> UploadImage(IFormFile file)
        {
            string connectionString = "DefaultEndpointsProtocol=https;AccountName=sjmusicstorageaccount;AccountKey=ywNbk8vCjqXoreVJEEP8NDIePwI+VUwpFwe1rPf+vRnYKafZ0eIffD/UQQr3TDEHZij93piR4Fft+ASt82jTDA==;EndpointSuffix=core.windows.net";

            string containerName = "songscover";

            BlobContainerClient blobContainerClient = new BlobContainerClient(connectionString, containerName);
            BlobClient blobClient = blobContainerClient.GetBlobClient(file.FileName);
            var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            memoryStream.Position = 0;
            await blobClient.UploadAsync(memoryStream);
            return blobClient.Uri.AbsoluteUri;
        }
    }
}

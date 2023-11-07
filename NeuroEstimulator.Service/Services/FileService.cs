using Azure.Storage;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;

namespace NeuroEstimulator.Service.Services;

public class FileService
{
    private readonly string _storageAccount = "storageneuroestimulator";
    private readonly string _accessKey = "tVp+jDfDgRYYefcuf+/C7jzbduCFlW3p4sJkuopDwvGHuWm76nKJHi7lMpjs50Q2Cy16hDK7C/Oe+AStI0ZVyA==";
    private readonly BlobContainerClient _filesContainer;

    public FileService()
    {
        var credential = new StorageSharedKeyCredential(_storageAccount, _accessKey);
        var blobUri = $"https://{_storageAccount}.blob.core.windows.net";
        var blobServiceClient = new BlobServiceClient(new Uri(blobUri), credential);
        _filesContainer = blobServiceClient.GetBlobContainerClient("files");
    }

    public async Task UploadAsync(IFormFile blob)
    {
        BlobClient client = _filesContainer.GetBlobClient(blob.Name);

        await using (Stream? data = blob.OpenReadStream())
        {
            await client.UploadAsync(data);
        }

    }

    public async Task DownloadAsync(string blobFilename)
    {
        BlobClient file = _filesContainer.GetBlobClient(blobFilename);

        if(await file.ExistsAsync())
        {
            var data = await file.OpenReadAsync();
            Stream blobContent = data;

            var content = await file.DownloadContentAsync();

        }

    }

    public async Task DeleteAsync(string blobFilename)
    {
        BlobClient file = _filesContainer.GetBlobClient(blobFilename);

        await file.DeleteAsync();
    }

}

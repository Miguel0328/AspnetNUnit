using AspnetNUnit.Extensions;
using System.Net;

namespace AspnetNUnit.Mocking
{
    public interface IFileDownloader
    {
        Task DownloadFileAsync(string url, string path);
    }

    public class FileDownloader : IFileDownloader
    {
        public async Task DownloadFileAsync(string url, string path)
        {
            using var client = new HttpClient();
            var fileName = @"C:\temp\imgd.jpg";
            var uri = new Uri("https://yourwebsite.com/assets/banners/Default.jpg");

            await client.DownloadFileAsync(uri, fileName);
        }
    }
}
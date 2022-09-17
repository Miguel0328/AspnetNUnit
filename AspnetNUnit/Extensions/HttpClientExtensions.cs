using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspnetNUnit.Extensions
{
    public static class HttpClientExtensions
    {
        public static async Task DownloadFileAsync(this HttpClient client, Uri uri, string FileName)
        {
            using var s = await client.GetStreamAsync(uri);
            using var fs = new FileStream(FileName, FileMode.CreateNew);
            await s.CopyToAsync(fs);
        }
    }
}

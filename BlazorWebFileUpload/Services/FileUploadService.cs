using Microsoft.AspNetCore.Components.Forms;
using System.Net.Http.Headers;

namespace BlazorWebFileUpload.Services
{
    public class FileUploadService:IFileUploadService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<FileUploadService> _logger;

        public FileUploadService(HttpClient httpClient, ILogger<FileUploadService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<HttpResponseMessage> UploadFiles(List<UploadFile> files, string url)
        {
            using var content = new MultipartFormDataContent();
            foreach (var uploadFile in files)
            {
                try
                {
                    var streamContent = new StreamContent(uploadFile.Content);
                    streamContent.Headers.ContentType = new MediaTypeHeaderValue(uploadFile.ContentType);
                    content.Add(streamContent, "files", uploadFile.Name);
                }
                catch (Exception ex)
                {
                    _logger.LogError("File: {Filename} Error: {Error}", uploadFile.Name, ex.Message);
                }
            }
            
              return await _httpClient.PostAsync(url, content);
            
        }   
    }
}

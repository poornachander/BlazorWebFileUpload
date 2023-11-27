using Microsoft.AspNetCore.Components.Forms;

namespace BlazorWebFileUpload.Services
{
    public interface IFileUploadService
    {
        Task<HttpResponseMessage> UploadFiles(List<UploadFile> files, string url);
    }
}

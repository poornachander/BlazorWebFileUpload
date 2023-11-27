using Microsoft.AspNetCore.Components.Forms;

namespace BlazorWebFileUpload.Services
{
    public class UploadFile
    {
        public string Name { get; set; }
        public long Size { get; set; }
        public string ContentType { get; set; }
        public Stream Content { get; set; }

        public UploadFile(IBrowserFile file)
        {
            Name = file.Name;
            Size = file.Size;
            ContentType = file.ContentType;
            Content = file.OpenReadStream();
        }

        // Additional properties or methods as required
    }

}

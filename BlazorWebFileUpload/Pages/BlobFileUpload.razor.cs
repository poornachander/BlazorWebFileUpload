using BlazorWebFileUpload.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;


namespace BlazorWebFileUpload.Pages
{
    public partial class BlobFileUpload : ComponentBase
    {
        private List<UploadFile> loadedFiles = new();
        private long maxFileSize = 1024 * 15;
        private int maxAllowedFiles = 3;
        private bool isLoading;
        HttpResponseMessage message;
        public bool IsVisible { get; set; }
        public bool IsErrorMessage { get; set; }
        public void Show() => IsVisible = true;

        private void Close() => IsVisible = false;
        public void Show1() => IsVisible = true;

        private void Close1() => IsVisible = false;

        private async Task LoadFiles(InputFileChangeEventArgs e)
        {
            isLoading = true;
            

            var files = e.GetMultipleFiles();
            foreach (var file in files)
            {
                var uploadFile = new UploadFile(file);
                loadedFiles.Add(uploadFile);
            }
            isLoading = false;
        }

        private async Task UploadFiles() 
        {             
           isLoading = true;
           message = await _fileUploadService.UploadFiles(loadedFiles, _configuration["endpoint"]);
           if(message.IsSuccessStatusCode)
           {
                isLoading = false;
                IsVisible = true;
                loadedFiles.Clear();
           }
            else
            {
                isLoading = false;
                IsErrorMessage = true;
                loadedFiles.Clear();
            }
        }

        private void RemoveFile(UploadFile file)
        {
            loadedFiles.Remove(file);
        }
    }
}

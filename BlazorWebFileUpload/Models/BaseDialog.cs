namespace BlazorWebFileUpload.Models
{
    public class BaseDialog
    {
        public bool IsVisible { get; protected set; }

        public void Show() => IsVisible = true;
        public void Close() => IsVisible = false;
    }
}

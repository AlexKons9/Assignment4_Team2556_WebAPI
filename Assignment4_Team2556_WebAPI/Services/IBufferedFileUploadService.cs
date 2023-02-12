namespace Assignment4_Team2556_WebAPI.Services
{
    public interface IBufferedFileUploadService
    {
        Task<bool> UploadFile(IFormFile file);
    }
}

using Microsoft.AspNetCore.Components.Forms;

namespace BlazorStoreServAppV5.Repository.StoreLogic.FileOploading
{
    public class FileUploadService
    {
        private readonly string uploadFolder = Path.Combine("wwwroot", "PictUploads");

        public async Task<string> UploadFileAsync(IBrowserFile file)
        {
            var fileExtension = Path.GetExtension(file.Name);
            var fileName = Path.GetRandomFileName() + fileExtension;

            var filePath = Path.Combine(uploadFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.OpenReadStream().CopyToAsync(stream);
            }

            return filePath;
        }
    }
}

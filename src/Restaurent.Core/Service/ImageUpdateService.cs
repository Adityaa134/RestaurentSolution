using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Restaurent.Core.ServiceContracts;

namespace Restaurent.Core.Service
{
    public class ImageUpdateService : IImageUpdateService
    {
        private readonly IHostEnvironment _hostEnvironment;
        private readonly IImageDeleteService _imageDeleteService;

        public ImageUpdateService(IHostEnvironment hostEnvironment, IImageDeleteService imageDeleteService)
        {
            _hostEnvironment = hostEnvironment;
            _imageDeleteService = imageDeleteService;
        }

        public async Task<string> ImageUpdater(IFormFile imageFile, string existingUrl, string subFolder = "Images")
        {

            if (string.IsNullOrWhiteSpace(existingUrl))
                throw new ArgumentException("Existing image URL cannot be null or empty");

            if (imageFile == null || imageFile.Length == 0)
                throw new ArgumentException("New image file is required");

            // Get wwwroot path
            var webRootPath = Path.Combine(_hostEnvironment.ContentRootPath, "wwwroot");

            // Ensure images directory exists
            var imagesDirectory = Path.Combine(webRootPath, subFolder);
            if (!Directory.Exists(imagesDirectory))
            {
                Directory.CreateDirectory(imagesDirectory);
            }

            // Generating new filename and paths
            var newFileName = $"{Guid.NewGuid()}_{Path.GetFileName(imageFile.FileName)}";
            var newRelativePath = Path.Combine(subFolder, newFileName);
            var newAbsolutePath = Path.Combine(webRootPath, newRelativePath);

            // Save new image
            using (var stream = new FileStream(newAbsolutePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }

            // Deleting old image if it exists
            if (!string.IsNullOrWhiteSpace(existingUrl))
            {
                await _imageDeleteService.ImageDeleter(existingUrl);
            }

            // Return new relative URL (with forward slashes)
            return $"/{newRelativePath.Replace("\\", "/")}";

        }
    }
}

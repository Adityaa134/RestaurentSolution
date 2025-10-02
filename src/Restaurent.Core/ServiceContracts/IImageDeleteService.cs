using System;

namespace Restaurent.Core.ServiceContracts
{
    public interface IImageDeleteService
    {
        /// <summary>
        /// Delete image from web folder
        /// </summary>
        /// <param name="imagePath">the image path to delete</param>
        /// <returns>Returns true if deleted; otherwise false</returns>
        Task<bool> ImageDeleter(string imagePath);
    }
}

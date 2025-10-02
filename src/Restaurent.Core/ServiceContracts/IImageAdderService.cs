using System;
using Microsoft.AspNetCore.Http;

namespace Restaurent.Core.ServiceContracts
{
    public interface IImageAdderService
    {
        /// <summary>
        /// Adds image in the web folder
        /// </summary>
        /// <param name="imageFile">the image to add</param>
        /// <returns>Returns the path of image </returns>
         Task<string> ImageAdder(IFormFile imageFile, string subFolder = "Images");
    }
}

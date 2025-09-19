using System;

namespace Restaurent.Core.ServiceContracts
{
    public interface IDishDeleteService
    {
        /// <summary>
        /// Delete a dish from the database
        /// </summary>
        /// <param name="dishId">The dishId of the product to  delete</param>
        /// <returns>Returns true if the dish is deleted; otherwise false</returns>
        Task<bool> DeleteDish(Guid? dishId);
    }
}

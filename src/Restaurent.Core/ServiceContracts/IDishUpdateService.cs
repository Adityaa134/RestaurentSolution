using System;
using Restaurent.Core.DTO;

namespace Restaurent.Core.ServiceContracts
{
    public interface IDishUpdateService
    {
        /// <summary>
        /// Update the existing dish 
        /// </summary>
        /// <param name="dishUpdateRequest">Contains Updated details of dish</param>
        /// <returns>Returns the updated details of dish</returns>
        Task<DishResponse> UpdateDish(DishUpdateRequest? dishUpdateRequest);
    }
}

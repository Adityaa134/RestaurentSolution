using System;
using Restaurent.Core.DTO;

namespace Restaurent.Core.ServiceContracts
{
    public interface IDishAdderService
    {
        /// <summary>
        /// Adds a dish to the database
        /// </summary>
        /// <param name="dishAddRequest">Contains the dish details to add</param>
        /// <returns>Returns the added dish details</returns>
        Task<DishResponse> AddDish(DishAddRequest? dishAddRequest);
    }
}

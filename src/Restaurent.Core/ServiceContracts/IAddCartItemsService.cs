using System;
using Restaurent.Core.DTO;

namespace Restaurent.Core.ServiceContracts
{
    public interface IAddCartItemsService
    {
        /// <summary>
        /// Adds the item in cart 
        /// </summary>
        /// <param name="addToCart">The dish to add</param>
        /// <returns></returns>
        Task<AddToCartResponse> AddItemToCart(AddToCartRequest addToCart);
    }
}

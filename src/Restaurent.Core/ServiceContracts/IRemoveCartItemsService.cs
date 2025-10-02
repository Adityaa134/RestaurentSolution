using System;

namespace Restaurent.Core.ServiceContracts
{
    public interface IRemoveCartItemsService
    {
        /// <summary>
        /// Removes the cart item of from the data store
        /// </summary>
        /// <param name="cartId">The cart which is to remove</param>
        /// <returns>Returns true if deleted; otherwiese false</returns>
        Task<bool> RemoveCartItem(Guid cartId);
    }
}

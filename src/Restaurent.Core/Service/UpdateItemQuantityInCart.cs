﻿using System;
using Restaurent.Core.Domain.Entities;
using Restaurent.Core.Domain.RepositoryContracts;
using Restaurent.Core.DTO;
using Restaurent.Core.ServiceContracts;

namespace Restaurent.Core.Service
{
    public class UpdateItemQuantityInCart : IUpdateItemQuantityInCart
    {
        private readonly ICartsRepository _cartsRepository;

        public UpdateItemQuantityInCart(ICartsRepository cartsRepository)
        {
            _cartsRepository = cartsRepository;
        }

        public async Task<AddToCartResponse> UpdateDishQuantityInCartItem(UpdateQuantityRequest updateQuantityRequest)
        {
            if (updateQuantityRequest.CartId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(updateQuantityRequest));
            }

            Carts? cart = await _cartsRepository.GetCartItemByCartId(updateQuantityRequest.CartId);

            if (cart == null)
                throw new ArgumentNullException("cart Item does not exist for the current user");

            Carts updatedCart = await _cartsRepository.UpdateCartItemQuantity(cart, updateQuantityRequest.Quantity);
            return updatedCart.ToAddToCartResponse();
        }
    }
}

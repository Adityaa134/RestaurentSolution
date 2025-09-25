using System;
using Restaurent.Core.Domain.Entities;
using Restaurent.Core.Domain.RepositoryContracts;
using Restaurent.Core.DTO;
using Restaurent.Core.Helpers;
using Restaurent.Core.ServiceContracts;

namespace Restaurent.Core.Service
{
    public class AddCartItemsService : IAddCartItemsService
    {
        private readonly ICartsRepository _cartsRepository;
        public AddCartItemsService(ICartsRepository cartsRepository)
        {
            _cartsRepository = cartsRepository;
        }

        public async Task<AddToCartResponse> AddItemToCart(AddToCartRequest addToCart)
        {
            if (addToCart == null)
                throw new ArgumentNullException(nameof(addToCart));

            ValidationHelper.ModelValidator(addToCart);

            Carts cart = addToCart.ToCart();
            cart.Id = Guid.NewGuid();

            Carts cartItem = await _cartsRepository.AddItemToCart(cart);

            return cartItem.ToAddToCartResponse();
        }
    }
}

using System.ComponentModel.DataAnnotations;
using Restaurent.Core.Domain.Entities;

namespace Restaurent.Core.DTO
{
    public class AddToCartRequest
    {
        public Guid? UserId { get; set; }
        [Required]
        public Guid? DishId { get; set; }
        public int Quantity { get; set; } = 1;

        public Carts ToCart()
        {
            return new Carts()
            {
                UserId = UserId,
                DishId = DishId.Value,
                Quantity = Quantity
            };
        }
    }
}

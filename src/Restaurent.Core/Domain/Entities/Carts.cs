using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Restaurent.Core.Domain.Identity;

namespace Restaurent.Core.Domain.Entities
{
    public class Carts
    {
        [Key]
        public Guid Id { get; set; }
        public int Quantity { get; set; } = 1;
        public Guid DishId { get; set; }
        public Guid? UserId { get; set; }

        //Navigation Properties
        [ForeignKey(nameof(UserId))]
        public ApplicationUser? Users { get; set; }  

        [ForeignKey(nameof(DishId))]
        public Dish Dishes { get; set; } 
    }
}


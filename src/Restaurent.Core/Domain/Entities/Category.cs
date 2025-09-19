using System;
using System.ComponentModel.DataAnnotations;

namespace Restaurent.Core.Domain.Entities
{
    public class Category
    {
        [Key] 
        public Guid Id { get; set; }

        [StringLength(200)]
        public string CategoryName { get; set; }
        public bool Status { get; set; } 
        public string? Cat_Image { get; set; }

        public IEnumerable<Dish> Dishes { get; set; } = new List<Dish>(); 

    }
}

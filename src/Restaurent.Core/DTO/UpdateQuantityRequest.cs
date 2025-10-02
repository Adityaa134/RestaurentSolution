using System;
using System.ComponentModel.DataAnnotations;

namespace Restaurent.Core.DTO
{
    public class UpdateQuantityRequest
    {
        public int Quantity { get; set; }
        [Required]
        public Guid CartId { get; set; }
    }
}

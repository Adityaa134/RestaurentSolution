using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Restaurent.Core.Domain.Identity
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string? RefreshToken { get; set; } 
        public DateTime RefershTokenExpirationDateTime { get; set; } 
    }
}

using System;

namespace Restaurent.Core.DTO
{
    public class TokenModel
    {
        public string? JwtToken { get; set; }
        public string? RefreshToken { get; set; }
    }
}

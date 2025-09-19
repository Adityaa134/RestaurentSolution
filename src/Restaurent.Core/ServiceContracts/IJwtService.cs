using System;
using System.Security.Claims;
using Restaurent.Core.Domain.Identity;
using Restaurent.Core.DTO;

namespace Restaurent.Core.ServiceContracts
{
    public interface IJwtService
    {
        /// <summary>
        /// Creates the JWT Token using the given user's information and configuration settings 
        /// </summary>
        /// <param name="user">ApplicationUser object</param>
        /// <returns>AuthenitcationResponse object that includes Token</returns> 

        Task<AuthenticationResponse> CreateJwtToken(ApplicationUser user);

        /// <summary>
        /// Validates the expired jwt token and returns principals if the token is valid. 
        /// </summary>
        /// <param name="token">The token to validate</param>
        /// <returns>Returns principal from the jwt expired token</returns>
        ClaimsPrincipal? GetPrincipalFromJwtToken(string? token);
    }
}

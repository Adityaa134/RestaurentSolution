using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Restaurent.Core.Domain.Identity;
using Restaurent.Core.DTO;
using Restaurent.Core.ServiceContracts;

namespace Restaurent.Core.Service
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;
        private readonly IAuthService _authService;

        public JwtService(IConfiguration configuration, IAuthService authService)
        {
            _configuration = configuration;
            _authService = authService;
        }

        public async Task<AuthenticationResponse> CreateJwtToken(ApplicationUser user)
        {
            //ExpirtaionTime of Jwt 
            DateTime expiration = DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:EXPIRATION_MINUTES"]));
            string userRole = await _authService.GetUserRole(user);

            //Claims
            Claim[] claims = new Claim[]
            {
                //userId
                new Claim(JwtRegisteredClaimNames.Sub,user.Id.ToString()),

                //JwtId
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),

                //Token Issued At Time
                new Claim(JwtRegisteredClaimNames.Iat,DateTimeOffset.Now.ToUnixTimeSeconds().ToString()),


                //unique name identifier for the user
                new Claim(JwtRegisteredClaimNames.Email,user.Email),

                //Name of the user
                new Claim(JwtRegisteredClaimNames.Name,user.UserName),

                //User Role
                new Claim("role", userRole.ToString()),
            };

            //passing secret key 
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));


            //Hashing Algorithm
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //Creates a JwtSecurityToken obejct with the given issuer,audience,claims,expires and signinCredentials 
            JwtSecurityToken tokenGenerator = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: expiration,
                signingCredentials: signingCredentials
                );

            //generating Jwt token
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            string token = tokenHandler.WriteToken(tokenGenerator);

            return new AuthenticationResponse()
            {
                Email = user.Email,
                Token = token,
                UserName = user.UserName,
                Expiration = expiration,
                RefreshToken = GenerateRefreshToken(),
                RefershTokenExpirationDateTime = DateTime.Now.AddMinutes(Convert.ToInt32(_configuration["RefreshToken:EXPIRATION_MINUTES"])),
                Role = await _authService.GetUserRole(user)
            };

        }

        //this method is used to check whether the expired Jwt token is valid or not 
        public ClaimsPrincipal? GetPrincipalFromJwtToken(string? token)
        {
            
            TokenValidationParameters validationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidIssuer = _configuration["Jwt:Issuer"],
                ValidateAudience = true,
                ValidAudience = _configuration["Jwt:Audience"],

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])),

                ValidateLifetime = false, // it should be false as we have to check the expired Jwt Token 
            };

            //For extarcting the payload from the token and for validating the token
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            
            ClaimsPrincipal principal = jwtSecurityTokenHandler.ValidateToken(token, validationParameters, out SecurityToken securityToken);

            
            if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.OrdinalIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token ");
            }

            
            return principal;
        }


        private string GenerateRefreshToken()
        {
            byte[] bytes = new byte[64];
            var randomNumberGenerator = RandomNumberGenerator.Create();

            randomNumberGenerator.GetBytes(bytes);

            return Convert.ToBase64String(bytes);

        }

    }
}

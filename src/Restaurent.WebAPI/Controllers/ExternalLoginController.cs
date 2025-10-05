﻿using Google.Apis.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Restaurent.Core.Domain.Identity;
using Restaurent.Core.DTO;
using Restaurent.Core.Service;
using Restaurent.Core.ServiceContracts;

namespace Restaurent.WebAPI.Controllers
{
    [AllowAnonymous]
    public class ExternalLoginController : CustomControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IJwtService _jwtService;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public ExternalLoginController(IAuthService authService, IJwtService jwtService, SignInManager<ApplicationUser> signInManager)
        {
            _authService = authService;
            _jwtService = jwtService;
            _signInManager = signInManager;
        }

        [HttpPost("signin-google")]
        public async Task<ActionResult> GoogleLogin(string credential)
        {
            //  Validating the Google token
            GoogleJsonWebSignature.Payload payload = await GoogleJsonWebSignature.ValidateAsync(credential);
            var result = await _authService.Register(payload);
            if(result == null)
            {
                ApplicationUser? user = await _authService.FindUserByEmail(payload.Email);
                if (user == null)
                {
                    return Problem("Invalid Email Id");
                }

                if (!user.EmailConfirmed)
                {
                    return Problem("Please verify your emailId to login");
                }
                AuthenticationResponse authenticationResponse = await _jwtService.CreateJwtToken(user);
                await _authService.UpdateRefreshTokenInTable(user, authenticationResponse);
                await _signInManager.SignInAsync(user, isPersistent: false);
                return Ok(authenticationResponse);
            }
            if (result.Succeeded)
            {
                ApplicationUser? user = await _authService.FindUserByEmail(payload.Email);
                if (user == null)
                {
                    return Problem("Invalid Email Id");
                }

                if (!user.EmailConfirmed)
                {
                    return Problem("Please verify your emailId to login");
                }
                AuthenticationResponse authenticationResponse = await _jwtService.CreateJwtToken(user);
                await _authService.UpdateRefreshTokenInTable(user, authenticationResponse);
                await _signInManager.SignInAsync(user, isPersistent: false);
                return Ok(authenticationResponse);
            }
            return Problem("Invalid credentials");
        }
    }
}

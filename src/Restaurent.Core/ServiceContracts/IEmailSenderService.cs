using System;
using Restaurent.Core.Domain.Identity;

namespace Restaurent.Core.ServiceContracts
{
    public interface IEmailSenderService
    {
        /// <summary>
        /// Send's email confirmation email to  user email address 
        /// </summary>
        /// <param name="user">The user information</param>
        /// <param name="token">The email confirmation token</param>
        /// <returns></returns>
        Task SendEmailConfirmation(ApplicationUser user, string token);

        /// <summary>
        /// Send's forgot passwrd  email to  user email address 
        /// </summary>
        /// <param name="user">The user information</param>
        /// <param name="token">The forgot password token</param>
        /// <returns></returns>
        Task SendForgotPasswordEmail(ApplicationUser user, string token);
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace Restaurent.Core.DTO
{
    public class ResetPasswordDTO
    {
        [Required]
        public string Uid { get; set; }
        [Required]
        public string Token { get; set; }

        [Required(ErrorMessage = "Password can't be blank")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password can't be blank")]
        [Compare("Password", ErrorMessage = "Password and Confirm Password do not match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public bool IsPasswordChangedSuccessfully { get; set; }
    }
}

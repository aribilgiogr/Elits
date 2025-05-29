using System.ComponentModel.DataAnnotations;

namespace UI.Web.Models.Account
{
    public class ResetPasswordViewModel
    {
        [Required, EmailAddress, Display(Name = "Email Address")]
        public required string Email { get; set; }

        [Required, Display(Name = "Password", Prompt = "Password"), DataType(DataType.Password)]
        public required string Password { get; set; }

        [Required, Display(Name = "Confirm Password", Prompt = "Confirm Password"), DataType(DataType.Password), Compare("Password")]
        public required string ConfirmPassword { get; set; }

        [Required, Display(Name = "Reset Code")]
        public required string Code { get; set; }
    }
}

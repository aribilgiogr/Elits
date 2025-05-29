using System.ComponentModel.DataAnnotations;

namespace UI.Web.Models.Account
{
    public class ForgotPasswordViewModel
    {
        [Required, EmailAddress, Display(Name = "Email Address")]
        public required string Email { get; set; }
    }
}

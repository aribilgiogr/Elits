using System.ComponentModel.DataAnnotations;

namespace UI.Web.Models.Account
{
    public class RegisterViewModel
    {
        [Required, Display(Name = "Email Address", Prompt = "Email Address"), EmailAddress]
        public required string Email { get; set; }

        [Required, Display(Name = "UserName", Prompt = "UserName")]
        public required string UserName { get; set; }

        [Required, Display(Name = "Password", Prompt = "Password"), DataType(DataType.Password)]
        public required string Password { get; set; }

        [Required, Display(Name = "Confirm Password", Prompt = "Confirm Password"), DataType(DataType.Password), Compare("Password")]
        public required string ConfirmPassword { get; set; }

        #region Optional Data

        [Display(Name = "FirstName", Prompt = "FirstName")]
        public string? FirstName { get; set; }

        [Display(Name = "LastName", Prompt = "LastName")]
        public string? LastName { get; set; }

        [Display(Name = "Biography", Prompt = "Biography"), DataType(DataType.MultilineText)]
        public string? Bio { get; set; }

        [Display(Name = "Profile Picture", Prompt = "Profile Picture"), DataType(DataType.Upload)]
        public IFormFile? ProfilePicture { get; set; }
        public string? ProfilePictureUrl { get; set; }

        #endregion
    }
}

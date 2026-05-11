using System.ComponentModel.DataAnnotations;

namespace Bookstore.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Please enter your first name.")]
        [StringLength(255)]
        [Display(Name = "First Name")]
        public string Firstname { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter your last name.")]
        [StringLength(255)]
        [Display(Name = "Last Name")]
        public string Lastname { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter an email address.")]
        [StringLength(255)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a username.")]
        [StringLength(255)]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a password.")]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please confirm your password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}

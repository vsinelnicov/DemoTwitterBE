using System.ComponentModel.DataAnnotations;

namespace DemoTwitter.Models
{
    public class User
    {
        public int Id { get; set; }

        [Display(Name = "Username")]
        [Required(ErrorMessage = "Enter your username")]
        public string Username { get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [StringLength(24, MinimumLength = 4, ErrorMessage = "Password must have from 4 to 24 characters")]
        [Display(Name = "Password")]
        [Required]
        public string Password { get; set; }

        [StringLength(24, MinimumLength = 4, ErrorMessage = "First name must have from 4 to 24 characters")]
        [Display(Name = "First name")]
        [Required(ErrorMessage = "Enter your firstname")]
        public string FirstName { get; set; }

        [StringLength(24, MinimumLength = 4, ErrorMessage = "Last name must have from 4 to 24 characters")]
        [Display(Name = "Last name")]
        [Required(ErrorMessage = "Enter your lastname")]
        public string LastName { get; set; }
    }
}
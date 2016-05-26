using System.ComponentModel.DataAnnotations;


namespace DemoTwitter.Models
{

    public class User
    {
        public int? Id { get; set; }

        [Display(Name = "Username")]
        [Required(ErrorMessage = "Enter your username")]
        [StringLength(24, MinimumLength = 4, ErrorMessage = "Username must have from 4 to 24 characters")]
        public string Username { get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [RegularExpression(@"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))", ErrorMessage = "Invalid Email Form")]
        public string Email { get; set; }

        [StringLength(24, MinimumLength = 4, ErrorMessage = "Password must have from 4 to 24 characters")]
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Enter your password")]
        public string Password { get; set; }

        [StringLength(24, MinimumLength = 1, ErrorMessage = "First name must have from 1 to 24 characters")]
        [Display(Name = "First name")]
        [Required(ErrorMessage = "Enter your firstname")]
        public string FirstName { get; set; }

        [StringLength(24, MinimumLength = 1, ErrorMessage = "Last name must have from 1 to 24 characters")]
        [Display(Name = "Last name")]
        [Required(ErrorMessage = "Enter your lastname")]
        public string LastName { get; set; }

        [Display(Name = "Avatar")]
        public string Avatar { get; set; }

        public bool IsFollowed { get; set; }
    }
}
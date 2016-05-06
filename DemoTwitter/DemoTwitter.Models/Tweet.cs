using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DemoTwitter.Models
{
    public class Tweet
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        [Required]
        [StringLength(140)]
        [DataType(DataType.MultilineText)]
        [RegularExpression(@"^[\S]*$", ErrorMessage = "White space found")]
        public string Text { get; set; }

        [DisplayName("Post date")]
        public DateTime PostDate { get; set; }
    }
}

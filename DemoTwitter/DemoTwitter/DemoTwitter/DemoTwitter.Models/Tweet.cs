using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoTwitter.Models
{
    public class Tweet
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Text { get; set; }

        public DateTime PostDate { get; set; }
    }
}

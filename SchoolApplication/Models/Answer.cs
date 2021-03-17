using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolApplication.Models
{
    public class Answer
    {
        public Guid Id { get; set; }

        [Required]
        public string Text { get; set; }
        public Question Question { get; set; }

    }
}

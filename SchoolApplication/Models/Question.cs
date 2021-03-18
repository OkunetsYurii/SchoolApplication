
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolApplication.Models
{
    public class Question
    {
        public Guid Id { get; set; }

        [Required]
        public string Text { get; set; }

        public Guid TestId { get; set; }
        public Test Test { get; set; }
        public List<Answer> Answers { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolApplication.Models
{
    public class CorrectAnswer
    {
        public Guid Id { get; set; }

        [Required]
        public int AnswerNumber { get; set; }
        public Guid QuestionId { get; set; }
        public Question Question { get; set; }
    }
}

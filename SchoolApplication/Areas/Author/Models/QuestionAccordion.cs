using SchoolApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApplication.Areas.Author.Models
{
    public class QuestionAccordion
    {
        public string Id { get; set; }
        public string Class { get; set; }
        public ICollection<Question> Questions { get; set; }
        public bool UseHiddenInput { get; set; }
    }
}

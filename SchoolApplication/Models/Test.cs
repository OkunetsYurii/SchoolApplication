using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolApplication.Models
{
    public class Test
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public IdentityUser Instructor { get; set; }
        public ICollection<UserTest> UserCourses { get; set; }
        public ICollection<Question> Questions { get; set; }
    }

}

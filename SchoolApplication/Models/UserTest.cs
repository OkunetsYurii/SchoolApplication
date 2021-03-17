using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolApplication.Models
{
    public class UserTest
    {
        public Guid Id { get; set; }

        [Required]
        public IdentityUser User { get; set; }

        [Required]
        public Test Test { get; set; }
    }
}

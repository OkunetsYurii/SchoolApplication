using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolApplication.Models
{
    public class News
    {
        public Guid Id { get; set; }

        [Required]
        public string Text { get; set; }
        public string AttachedLink { get; set; }
        public string AttachedLinkName { get; set; }

    }
}

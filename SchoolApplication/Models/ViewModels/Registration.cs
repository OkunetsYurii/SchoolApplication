using System.ComponentModel.DataAnnotations;

namespace SchoolApplication.Models.ViewModels
{
    public class Registration
    {
        [Required(ErrorMessage = "Не указан Email")]
        [Display(Name = "Логин")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [UIHint("password")]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        public bool IsAuthor { get; set; }
    }
}

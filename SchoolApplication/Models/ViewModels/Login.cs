using System.ComponentModel.DataAnnotations;

namespace SchoolApplication.Models.ViewModels
{
    public class Login
    {
        [Required(ErrorMessage ="Не указан Email")]
        [Display(Name = "Логин")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Не указан пароль")]
        [UIHint("password")]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Запомнить меня?")]
        public bool RememberMe { get; set; }
    }
}

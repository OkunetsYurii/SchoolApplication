using Microsoft.AspNetCore.Mvc;
using SchoolApplication.Models.ViewModels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace SchoolApplication.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Login login)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = await _userManager.FindByEmailAsync(login.UserName);
                if (user != null)
                {
                    await _signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user, login.Password, login.RememberMe, false);
                    if (result.Succeeded)
                        return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Некорректные логин или пароль");
            }
            return View(login);
        }
        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registration(Registration registration)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser { UserName = registration.UserName, Email = registration.UserName };
                var result = await _userManager.CreateAsync(user, registration.Password);
                if (result.Succeeded)
                {
                    //TODO Добавить обработку ошибки добавления
                    if (registration.IsAuthor)
                        await _userManager.AddToRoleAsync(user, "author");

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Некорректные логин или пароль");
            }
            return View(registration);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}

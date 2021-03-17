using Microsoft.AspNetCore.Mvc;
using SchoolApplication.Data;
using SchoolApplication.Models;
using System.Diagnostics;

namespace SchoolApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly SchoolDbContext _schoolDbContext;
        public HomeController(SchoolDbContext schoolDbContext)
        {
            _schoolDbContext = schoolDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

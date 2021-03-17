using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolApplication.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApplication.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        SchoolDbContext _schoolDbContext;
        public UserController(SchoolDbContext schoolDbContext)
        {
            _schoolDbContext = schoolDbContext;
        }
        public async Task<IActionResult> IndexAsync()
        {
            List<IdentityUserRole<string>> userCourses = await _schoolDbContext.UserRoles
                .ToListAsync();

            return View(userCourses);
        }
    }
}

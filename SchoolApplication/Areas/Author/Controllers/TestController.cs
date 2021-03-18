using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolApplication.Data;
using SchoolApplication.Models;

namespace SchoolApplication.Areas.Instructor
{
    [Area("Author")]
    [Authorize(policy: "AuthorArea")]
    public class TestController : Controller
    {
        private readonly SchoolDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public TestController(SchoolDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Tests
                .Where(u => u.Author.Email == User.Identity.Name)
                .AsNoTracking()
                .ToListAsync());
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var test = await _context.Tests
                .FirstOrDefaultAsync(m => m.Id == id);

            await _context.Entry(test).Collection(x => x.Questions).LoadAsync();

            foreach (Question question in test.Questions)
                await _context.Entry(question).Collection(x => x.Answers).LoadAsync();

            if (test == null)
            {
                return NotFound();
            }

            return View(test);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Test test)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(User.Identity.Name);
                test.Author = user;
                _context.Add(test);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(test);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var test = await _context.Tests.FindAsync(id);
            if (test == null)
            {
                return NotFound();
            }
            return View(test);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Description")] Test test)
        {
            if (id != test.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(test);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestExists(test.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(test);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var test = await _context.Tests
                .FirstOrDefaultAsync(m => m.Id == id);
            if (test == null)
            {
                return NotFound();
            }

            return View(test);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var test = await _context.Tests.FindAsync(id);
            _context.Tests.Remove(test);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TestExists(Guid id)
        {
            return _context.Tests.Any(e => e.Id == id);
        }
    }
}

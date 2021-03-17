using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolApplication.Data;
using SchoolApplication.Models;
using SchoolApplication.Models.ViewModels;
using SchoolApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApplication.Controllers
{
    [Authorize]
    public class TestController : Controller
    {
        SchoolDbContext _db;
        ITestProvider _testProvider;

        public TestController(SchoolDbContext schoolContext, ITestProvider testProvider)
        {
            _db = schoolContext;
            _testProvider = testProvider;
        }
        public async Task<IActionResult> Index()
        {
            List<UserTest> userCourses = await _db.UserTests
                .Where(u => u.User.Email == User.Identity.Name)
                .Include(u => u.Test)
                .AsNoTracking()
                .ToListAsync();

            return View(userCourses);
        }
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Index));

            Test test = await _db.Tests
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Id == id);

            return View(test);
        }
        public async Task<IActionResult> Result(int answerId)
        {
            await _testProvider.AcceptAnswer(answerId);
            var result = _testProvider.GetResult();
            _testProvider.EndTest();

            return View(result);
        }
        public IActionResult StartTest(Guid? id)
        {
            if (id == null && _testProvider.TestId == null)
                return RedirectToAction(nameof(Index));

            _testProvider.StartTest(id);
            return View();
        }

        public async Task<ActionResult<QuestionVM>> GetNextQuestion(int answerId)
        {
            await _testProvider.AcceptAnswer(answerId);
            return _testProvider.GetNextQuestion();
        }
        public ActionResult<QuestionVM> GetQuestion()
        {
            return _testProvider.GetQuestion();
        }

    }
}

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
            List<Test> tests = await _db.Tests
                .AsNoTracking()
                .ToListAsync();

            return View(tests);
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
        public async Task<IActionResult> Result(Guid answerId)
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

            return View(_testProvider.GetQuestion());
        }
        public PartialViewResult GetQuestion()
        {
            return PartialView("_Question", _testProvider.GetQuestion());
        }
        public async Task<PartialViewResult> GetNextQuestion(Guid answerId)
        {
            await _testProvider.AcceptAnswer(answerId);
            return PartialView("_Question", _testProvider.GetNextQuestion());
        }
    }
}

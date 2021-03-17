using Microsoft.AspNetCore.Http;
using SchoolApplication.Models.ViewModels;
using System;
using System.Threading.Tasks;

namespace SchoolApplication.Services
{
    public class TestProvider : ITestProvider
    {
        private readonly HttpContext _httpContext;
        private readonly IQuestionProvider _questionProvider;
        public Guid? TestId
        {
            get => new Guid(_httpContext.Session.GetString("TestID"));
            set => _httpContext.Session.SetString("TestID", value.ToString());
        }
        public int? CountCorrectAnswers
        {
            get => _httpContext.Session.GetInt32("CorrectAnswers");
            set => _httpContext.Session.SetInt32("CorrectAnswers", (int)value);
        }
        public int? QuestionNumber
        {
            get => _httpContext.Session.GetInt32("QuestionNumber");
            set => _httpContext.Session.SetInt32("QuestionNumber", (int)value);
        }
        public IQuestionProvider QuestionProvider
        {
            get
            {
                _questionProvider.TestId = (Guid)TestId;
                return _questionProvider;
            }
        }

        public TestProvider(IHttpContextAccessor httpContextAccessor, IQuestionProvider questionProvider)
        {
            _httpContext = httpContextAccessor.HttpContext;
            _questionProvider = questionProvider;
        }
        public Result GetResult()
        {
            return new Result
            {
                Count = (int)CountCorrectAnswers
            };
        }

        public void StartTest(Guid? testId)
        {
            if (testId != null)
                TestId = testId;

            if (CountCorrectAnswers == null)
                CountCorrectAnswers = 0;

            if (QuestionNumber == null)
                QuestionNumber = 0;
        }

        public async Task AcceptAnswer(int answerId)
        {
            if (await QuestionProvider.CheckAnswer((int)QuestionNumber, answerId))
                CountCorrectAnswers++;
        }

        public void EndTest()
        {
            _httpContext.Session.Remove("TestID");
            _httpContext.Session.Remove("QuestionNumber");
            _httpContext.Session.Remove("CorrectAnswers");
        }

        public QuestionVM GetQuestion()
        {
            return QuestionProvider.GetQuestion((int)QuestionNumber);
        }

        public QuestionVM GetNextQuestion()
        {
            QuestionNumber++;
            return QuestionProvider.GetQuestion((int)QuestionNumber);
        }
    }
}

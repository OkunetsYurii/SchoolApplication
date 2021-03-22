using SchoolApplication.Models.ViewModels;
using System;
using System.Threading.Tasks;

namespace SchoolApplication.Services
{
    public interface ITestProvider
    {
        public Guid? TestId { get; set; }
        public int? CountCorrectAnswers { get; set; }
        public void StartTest(Guid? testId);
        public QuestionVM GetQuestion();
        public QuestionVM GetNextQuestion();
        public Task AcceptAnswer(Guid answerId);
        public Result GetResult();
        public void EndTest();
    }
}

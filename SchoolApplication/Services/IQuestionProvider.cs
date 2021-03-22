using SchoolApplication.Models.ViewModels;
using System;
using System.Threading.Tasks;

namespace SchoolApplication.Services
{
    public interface IQuestionProvider
    {
        public Guid TestId { get; set; }
        public QuestionVM GetQuestion(int questionNumber);
        public Task<bool> CheckAnswer(int questionNumber, Guid answerId);

    }
}

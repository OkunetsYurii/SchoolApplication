using Microsoft.EntityFrameworkCore;
using SchoolApplication.Data;
using SchoolApplication.Models;
using SchoolApplication.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApplication.Services
{
    public class QuestionProvider : IQuestionProvider
    {
        private readonly SchoolDbContext _db;
        private List<Question> questions;

        public Guid TestId { get; set; }
        public List<Question> Questions
        {
            get
            {
                if (questions == null)
                    questions = GetQuestionList();

                return questions;
            }
            set { questions = value; }
        }

        private List<Question> GetQuestionList()
        {
            return _db.Questions
                    .Where(q => q.Test.Id == TestId)
                    .Include(q => q.Answers)
                    .OrderBy(a => a.Id)
                    .ToList();
        }
        public QuestionProvider(SchoolDbContext schoolContext)
        {
            _db = schoolContext;
        }
        public async Task<bool> CheckAnswer(int questionNumber, Guid answerId)
        {
            var isCorrect = await _db.CorrectAnswers.AnyAsync(a =>
                a.QuestionId == Questions[questionNumber].Id &&
                a.AnswerId == answerId);

            return isCorrect;
        }
        public QuestionVM GetQuestion(int questionNumber)
        {
            if (questionNumber == Questions.Count() - 1)
                return new QuestionVM { Question = Questions[questionNumber], IsLast = true };

            return new QuestionVM { Question = Questions[questionNumber], IsLast = false };
        }

    }
}

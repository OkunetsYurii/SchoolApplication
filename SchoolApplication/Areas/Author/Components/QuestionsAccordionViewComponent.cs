using Microsoft.AspNetCore.Mvc;
using SchoolApplication.Areas.Author.Models;
using SchoolApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApplication.Areas.Author.Components
{
    public class QuestionsAccordionViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(QuestionAccordion settings)
        {
            string test = User.Identity.Name;
            return View(settings);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Application.Service.Interface;
using Application.ViewModel.UserQuestion;

namespace Oghabian.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserQuestionController : Controller
    {
        private readonly IUserQuestionService _question;

        public UserQuestionController(IUserQuestionService question)
        {
            _question = question;
        }
        [HttpGet][Route("/Admin/UserQuestions")]
        public IActionResult Index(int page=1,string search="")
        {
            var pageModel = _question.GetQuestions(page, search ?? "");
            ViewBag.Search = search;
            return View(pageModel);
        }

        [HttpGet]
        [Route("/Admin/UserQuestion/Detail/{id}")]
        public IActionResult Detail(string id)
        {
            var pageModel = _question.GetQuestionDetail(id).Result;
            return View(pageModel);
        }
        [HttpPost]
        [Route("/Admin/UserQuestion/Detail/{id}")]
        public IActionResult Detail(UserQuestionDetailViewModel model)
        {
         _question.ActiveQuestion(model);
         return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("/Admin/UserQuestion/Answers")]
        public IActionResult Answers(string id)
        {
            var pageModel = _question.GetAnswerById(id);
            return View(pageModel);
        }
        public string UserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
        [HttpGet]
        [Route("/Admin/UserQuestion/InsertAnswer")]
        public IActionResult InsertAnswer(string id)
        {
            InsertAnswerViewModel answer=new InsertAnswerViewModel();
            answer.UserId = UserId();
            answer.QuestionId = id;
            return View(answer);
        }

        [HttpPost]
        [Route("/Admin/UserQuestion/InsertAnswer")]
        public IActionResult InsertAnswer(InsertAnswerViewModel model)
        {
            if (ModelState.IsValid)
            {
                _question.InsertAnswer(model);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                model.UserId = UserId();
                return View(model);
            }
        }
        [HttpGet][Route("/Admin/UserQuestion/DeleteAnswer/{id}")]
        public void DeleteAnswer(string id)
        {
            _question.DeleteUserAnswer(id);
        } 
        [HttpGet][Route("/Admin/UserQuestion/DeleteQuestion/{id}")]
        public void DeleteQuestion(string id)
        {
            _question.DeleteUserQuestion(id);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Service.Interface;
using Application.ViewModel.Category;
using Application.ViewModel.Question;

namespace Oghabian.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class QuestionController : Controller
    {
        private readonly IQuestionService _question;

        public QuestionController(IQuestionService question)
        {
            _question = question;
        }
        [HttpGet][Route("/Admin/Questions")]
        public IActionResult Index(int page=1,string search="")
        {
            var pageModel = _question.GetQuestions(page, search ?? "");
            ViewBag.Search = search;
            return View(pageModel);
        }

        [HttpGet]
        [Route("/Admin/Question/Create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Route("/Admin/Question/Create")]
        public IActionResult Create(InsertQuestionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var check = _question.InsertQuestion(model);
                if (check)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Alert = "خطای سمت سرور با پشتیبانی ارتباط برقرا ر کنید";
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        [Route("/Admin/Question/Edit/{id}")]
        public IActionResult Edit(string id)
        {
            var pageModel = _question.GetQuestionById(id).Result;
            return View(pageModel);
        }

        [HttpPost]
        [Route("/Admin/Question/Edit/{id}")]
        public IActionResult Edit(UpdateQuestionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var check = _question.UpdateQuestion(model);
                if (check)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Alert = "خطای سمت سرور با پشتیبانی ارتباط برقرا ر کنید";
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        [Route("/Admin/Question/Delete/{id}")]
        public bool Delete(string id)
        {
            return _question.DeleteQuestion(id);
        }
    }

}

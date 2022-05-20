using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Drawing.Design;
using System.Linq;
using System.Threading.Tasks;
using Application.Service.Interface;
using Application.ViewModel.Article;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Oghabian.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleController : Controller
    {
        private readonly IArticleService _article;

        public ArticleController(IArticleService article)
        {
            _article = article;
        }
        [HttpGet][Route("/Admin/Articles")]
        public IActionResult Index(int page=1,string search="")
        {
            ViewBag.Search = search;
            var pageModel = _article.GetArticles(page, search ?? "");
            return View(pageModel);
        }

        [HttpGet]
        [Route("/Admin/Article/Create")]
        public IActionResult Create()
        {
            Category();
            return View();
        }

        [HttpPost]
        [Route("/Admin/Article/Create")]
        public IActionResult Create(InsertArticleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var check = _article.InsertArticle(model);
                if (check)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Alert = "خطای سمت سرور با پشتیبانی ارتباط برقرا ر کنید";
                    Category(model.CategoryId);
                    return View(model);
                }
            }
            else
            {
           
                Category(model.CategoryId);
                return View(model);
            }
        }


        [HttpGet]
        [Route("/Admin/Article/Edit/{id}")]
        public IActionResult Edit(string id)
        {
            var pageModel = _article.GetArticleById(id).Result;
            Category(pageModel.CategoryId);
            return View(pageModel);
        }

        [HttpPost]
        [Route("/Admin/Article/Edit/{id}")]
        public IActionResult Edit(UpdateArticleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var check = _article.UpdateArticle(model);
                if (check)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Alert = "خطای سمت سرور با پشتیبانی ارتباط برقرا ر کنید";
                    Category(model.CategoryId);
                    return View(model);
                }
            }
            else
            {
                ViewBag.Alert = null;
                Category(model.CategoryId);
                return View(model);
            }
        }

        [HttpGet]
        [Route("/Admin/Article/Delete/{id}")]
        public bool Delete(string id)
        {
            return _article.DeleteArticle(id);
        }

        [HttpGet]
        [Route("/Admin/Article/Seo/{id}")]
        public IActionResult Seo(string id)
        {
            var pageModel = _article.GetSeoViewModel(id).Result;
            return View(pageModel);
        }
        [HttpPost]
        [Route("/Admin/Article/Seo/{id}")]
        public IActionResult Seo(ArticleSeoViewModel model)
        {
           _article.ChangeSeo(model);
           return RedirectToAction(nameof(Seo), new {id = model.ArticleId});
        }
        public void Category(string selected = "")
        { 
            var result = _article.GetCategories().Result;
            ViewBag.Categories = new SelectList(result, "Value", "Text",selected);
        }

        [HttpGet]
        [Route("/Admin/Article/Comments")]
        public IActionResult Comments(string id, int page = 1, string search = "")
        {
            ViewBag.Id = id;
            ViewBag.Search = search;
            var pageModel = _article.GetComment(id,page, search ?? "");
            return View(pageModel);
        }

        [HttpGet]
        [Route("/Admin/Article/CommentDetail")]
        public IActionResult Detail(string id)
        {
            var pageModel = _article.GetCommentArticleDetail(id).Result;
          
            return View(pageModel);
        }

        [HttpPost]
        [Route("/Admin/Article/CommentDetail")]
        public IActionResult Detail(CommentArticleDetailViewModel model)
        {
            _article.UpdateComment(model);
            return RedirectToAction(nameof(Comments), new {id = model.ParentId});
        }

        [HttpGet]
        [Route("/Admin/Article/DeleteComment/{id}")]
        public void DeleteComment(string id)
        {
            _article.DeleteComment(id);
        }
    }
}

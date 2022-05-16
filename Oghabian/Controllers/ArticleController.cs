using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Application.Service.Interface;
using Application.ViewModel.Home.Blogs;

namespace Oghabian.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IHomeService _home;

        public ArticleController(IHomeService home)
        {
            _home = home;
        }
        [HttpGet][Route("/Blogs")]
        public IActionResult Blogs(string category,int page=1,string search="")
        {
            ViewBag.Search = search;
            ViewBag.Category = category;
            var pageModel = _home.GetBlogs(category, page, search ?? "");
            return View(pageModel);
        }
        [HttpGet]
        [Route("/BlogDetail")]
        public IActionResult BlogDetail(string id)
        {
            var pageModel = _home.GetBlogDetail(id).Result;
            return View(pageModel);
        }
        public string UserId()
        {
           return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
        [HttpGet]
        [Route("/InsertComment/{text}/{id}")]
        public void InsertComment(string text,string id)
        {
            InsertCommentViewModel comment = new InsertCommentViewModel()
            {
                CommentBody = text,
                ArticleId = id,
                UserId = UserId()
            };
            _home.InsertArticleComment(comment);
        }
    }
}

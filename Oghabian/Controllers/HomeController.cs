using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Oghabian.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Application.Service.Interface;
using Application.ViewModel.Home;
using Application.ViewModel.Home.Card;
using Domin.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Elasticsearch.Net;
using RestSharp;

namespace Oghabian.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService _home;
      
        public HomeController(IHomeService home)
        {
            _home = home;
        }
        [Route("/")]
        [Route("/index")]
        [Route("/home")]

        public IActionResult Index()
        {
            var pageModel = _home.GetLastFoods().Result;
            return View(pageModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet][Route("/404")]
        public new IActionResult NotFound()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public string UserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
        [HttpGet]
        [Route("/AddToCart/{id}")]
        public void AddToCart(string id)
        {
            AddToCardViewModel model=new AddToCardViewModel();
            model.FoodId = id;
            model.UserId = UserId();
            _home.AddToCart(model);
        }
        [HttpGet]
        [Route("/Question")]
        public IActionResult Question()
        {
            var pageModel = _home.Questions().Result;
            return View(pageModel);
        }

        [HttpGet]
        [Route("/Question/NewAnswer")]
        public IActionResult NewAnswer(string id)
        {
            ViewBag.User = UserId();
            ViewBag.Id = id;
            return View();
        }

        [HttpPost]
        [Route("/Question/NewAnswer")]
        public IActionResult NewAnswer(InsertUserAnswerViewModel model)
        {
            if (ModelState.IsValid)
            {
                _home.InsertAnswer(model);
                return RedirectToAction(nameof(Answer), new {id = model.Id});
            }
            else
            {
                ViewBag.User = UserId();
                ViewBag.Id = model.Id;
                return View(model);
            }
        }

        [HttpGet]
        [Route("/AddMail/{mail}")]
        public void AddMail(string mail)
        {
            AddMailViewModel model=new AddMailViewModel()
            { 
                Mail = mail
            };
            _home.AddMail(model);
        }

        [HttpGet]
        [Route("/Question/Answer")]
        public IActionResult Answer(string id)
        {
            ViewBag.Id = id;
            var pageModel = _home.Answer(id).Result;
            return View(pageModel);
        }

        [HttpGet]
        [Route("/AddQuestion")]
        public IActionResult AddQuestion(string message=null)
        {
            ViewBag.Alert = message;
            ViewBag.User = UserId();
            return View();
        }
        [HttpPost]
        [Route("/AddQuestion")]
        public IActionResult AddQuestion(InsertUserQuestionViewModel model)
        {
            if (ModelState.IsValid)
            {
                _home.InsertQuestion(model);
                return RedirectToAction(nameof(AddQuestion),
                    new {message = "سوال شما ثبت شد و بعد از تائید منتشر میشود"});
            }
            else
            {
                ViewBag.User = UserId();
                return View(model);
            }
         
        }

        [HttpGet]
        [Route("/ContactUs")]
        public IActionResult ContactUs(string message = null)
        {
            ViewBag.Alert = message;
            return View();
        }
        [HttpPost]
        [Route("/ContactUs")]
        public IActionResult ContactUs(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                _home.Insert(model);
                return RedirectToAction(nameof(ContactUs), new {message = "با تشکر پیام شما ثبت شد"});
            }
            else
            {
                return View(model);
            }
        }
        [HttpGet][Route("/Table")]
        public IActionResult Table(string id)
        {
            var pageModel = _home.GetTableById(id);
            return View(pageModel);
        }

        [HttpGet]
        [Route("/Supporter")]
        public IActionResult Supporter(string id)
        {
            var pageModel = _home.GetSupporterById(id).Result;
            return View(pageModel);
        }

        [HttpGet]
        [Route("/law")]
        public IActionResult Law()
        {
            var pageModel = _home.GetLaw().Result;
            return View(pageModel);
        }
    }
}

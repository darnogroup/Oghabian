using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Oghabian.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Application.Service.Interface;
using Application.ViewModel.Home.Card;
using Domin.Interfaces;

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
    }
}

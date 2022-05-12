using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Service.Interface;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Oghabian.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FoodController : Controller
    {
        private readonly IFoodService _food;

        public FoodController(IFoodService food)
        {
            _food = food;
        }
        [HttpGet][Route("/Admin/Foods")]
        public IActionResult Index(int page=1,string search="")
        {
            ViewBag.Search = search;
            var pageModel = _food.GetFoods(page, search ?? "");
            return View(pageModel);
        }

        [HttpGet]
        [Route("/Admin/Food/Create")]
        public IActionResult Create()
        {
            Meals();Sickness();
        }

        public void Sickness(string selectId = "")
        {
            var result = _food.GetSickness().Result;
            ViewBag.Sickness= new SelectList(result, "Value", "Text", selectId);
           
        }
        public void Meals(string selectId="")
        {
            var result = _food.GetMeals().Result;
            ViewBag.Meals = new SelectList(result,"Value","Text", selectId);
        }
    }
}

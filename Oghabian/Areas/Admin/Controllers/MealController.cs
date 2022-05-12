using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Service.Interface;
using Application.ViewModel.Meal;

namespace Oghabian.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MealController : Controller
    {
        private readonly IMealService _meal;

        public MealController(IMealService meal)
        {
            _meal = meal;
        }
        [HttpGet][Route("/Admin/Meals")]
        public IActionResult Index(int page=1,string search="")
        {
            ViewBag.Search = search;
            var pageModel = _meal.GetMeals(page, search ?? "");
            return View(pageModel);
        }

        [HttpGet]
        [Route("/Admin/Meal/Create")]
        public IActionResult Create()
        {
            ViewBag.Alert = null;
            return View();
        }

        [HttpPost]
        [Route("/Admin/Meal/Create")]
        public IActionResult Create(InsertMealViewModel model)
        {
            if (ModelState.IsValid)
            {
                var check = _meal.InsertMeal(model);
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
        [Route("/Admin/Meal/Edit/{id}")]
        public IActionResult Edit(string id)
        {
            var pageModel = _meal.GetMealById(id).Result;
            ViewBag.Alert = null;
            return View(pageModel);
        }

        [HttpPost]
        [Route("/Admin/Meal/Edit/{id}")]
        public IActionResult Edit(UpdateMealViewModel model)
        {
            if (ModelState.IsValid)
            {
                var check = _meal.UpdateMeal(model);

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
        [Route("/Admin/Meal/Delete/{id}")]
        public bool Delete(string id)
        {
            return _meal.DeleteMeal(id);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Application.Other;
using Application.Service.Interface;
using Application.ViewModel.Home.Card;
using Application.ViewModel.Home.ImmediateOrder;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Oghabian.Controllers
{
    public class ImmediateOrderController : Controller
    {
        private readonly IUserService _user;
        private readonly IFoodService _food;
        private readonly IHomeService _home;

        public ImmediateOrderController(IUserService user, IFoodService food, IHomeService home)
        {
            _user = user;
            _food = food;
            _home = home;
        }
        [HttpGet]
        public IActionResult SelectPerson()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SelectPerson(SelectPersonViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Person == 1)
                {
                    if (User.Identity.IsAuthenticated)
                    {
                        var medical = _user.GetMedicalInformationViewModel(UserId());
                        if (medical == null)
                        {
                            ViewBag.Alert = "پرونده پزشکی خود را تکمیل نمائید";
                            return View();
                        }
                    }
                    else
                    {
                        return Redirect("/signin");
                    }

                }

                if (model.Person == 1)
                {
                    return RedirectToAction(nameof(SelectDayAndMeal), new { person = model.Person });
                }
                else
                {
                    return RedirectToAction(nameof(SelectOtherDayAndMeal), new { person = model.Person });
                }
               
            }
            else
            {
                return View(model);
            }

        }

        [HttpGet]
        public IActionResult SelectDayAndMeal(int person)
        {
            if (person == 1)
            {

                ViewBag.Person = UserId();

            }
            else
            {
                ViewBag.Person = person;
            }
            Meals();
            return View();
        }

        [HttpPost]
        public IActionResult SelectDayAndMeal(SelectDayAndMealViewModel model)
        {
            if (ModelState.IsValid)
            {


                return RedirectToAction("SelectFood", model);

                
            }
            else
            {
                return View();
            }
        }


        [HttpGet]
        public IActionResult SelectFood(SelectDayAndMealViewModel option)
        {

            var pageModel = _home.GetFoodForce(option).Result;
            ViewBag.model = pageModel;
            ViewBag.Person = option.Person;
            return View();
        }

        [HttpPost]
        public IActionResult SelectFood(SelectFoodItemViewModel model)
        {
            if (model.Food.Count <= 0)
            {
                ViewBag.Alert = "لطفا یک آیتم انتخاب نمائید";
                ViewBag.Person = model.User;
                return View(model);
            }

            _home.FoodForceAddCard(model.Food, UserId(), UserId() == model.User);

            return Redirect("/Profile/Cart");
        }


        //*****************************************************************
        [HttpGet]
        public IActionResult SelectOtherDayAndMeal(int person)
        {
            if (person == 1)
            {

                ViewBag.Person = UserId();

            }
            else
            {
                ViewBag.Person = person;
            }
            Meals();
            return View();
        }


        [HttpPost]
        public IActionResult SelectOtherDayAndMeal(SelectDayAndMealViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction(nameof(Select), new { meal = model.Meal, person = model.Person, week = model.Week });
            }
            else
            {
                return View();
            }
        }




        [HttpGet]
        public IActionResult Select(string meal, string person, Week week)
        {
            SelectDayAndMealViewModel item = new SelectDayAndMealViewModel();
            item.Meal = meal;
            item.Person = person;
            item.Week = week;
            if (person == "2")
            {
                Sickness();
                return View();
            }
            else
            {
                return RedirectToAction(nameof(SelectFood), new { item = item });
            }

        }
        [HttpPost]
        public IActionResult Select(SelectDayAndMealViewModel model)
        {
            return RedirectToAction("SelectFood", model);
        }



















        public string UserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
        public void Meals(string selectId = "")
        {
            var result = _food.GetMeals().Result;
            ViewBag.Meals = new SelectList(result, "Value", "Text", selectId);
        }
        public void Sickness(string selectId = "")
        {
            var result = _food.GetSickness().Result;
            ViewBag.Sickness = new SelectList(result, "Value", "Text", selectId);

        }
    }
}

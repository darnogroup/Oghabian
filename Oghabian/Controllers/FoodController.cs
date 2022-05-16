﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Application.Service.Interface;
using Application.ViewModel.Home.Blogs;
using Application.ViewModel.Home.Foods;

namespace Oghabian.Controllers
{
    public class FoodController : Controller
    {
        private readonly IHomeService _home;

        public FoodController(IHomeService home)
        {
            _home = home;
        }
        [HttpGet][Route("/foods")]
        public IActionResult Foods(string calories, string carbohydrate, string fat, string protein,string meal,string sickness,int page=1,string search="")
        {
            ViewBag.carbohydrate = carbohydrate;
            ViewBag.calories = calories;
            ViewBag.protein = protein;
            ViewBag.fat = fat;
            ViewBag.sickness = sickness;
            ViewBag.meal = meal;
            var pageModel = _home.GetFoods(meal, sickness, calories, carbohydrate, fat, protein, page);
            return View(pageModel);
        }

        [HttpGet]
        [Route("/FoodDetail")]
        public IActionResult FoodDetail(string id)
        {
            var pageModel = _home.GetFoodDetail(id);
            return View(pageModel);
        }
        [HttpGet]
        [Route("/InsertFoodComment/{text}/{id}")]
        public void InsertComment(string text, string id)
        {
            InsertFoodCommentViewModel comment = new InsertFoodCommentViewModel()
            {
                CommentBody = text,
                FoodId = id,
                UserId = UserId()
            };
            _home.InsertFoodComment(comment);
        }
        public string UserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
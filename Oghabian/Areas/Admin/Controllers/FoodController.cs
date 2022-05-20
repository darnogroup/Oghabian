using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Service.Interface;
using Application.ViewModel.Food;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Oghabian.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FoodController : Controller
    {
        private readonly IFoodService _food;
        private readonly IPropertyService _property;
        private readonly IGalleryService _gallery;

        public FoodController(IFoodService food, IPropertyService property, IGalleryService gallery)
        {
            _food = food;
            _property = property;
            _gallery = gallery;
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
            return View();
        }

        [HttpPost]
        [Route("/Admin/Food/Create")]
        public IActionResult Create(InsertFoodViewModel model)
        {
            if (ModelState.IsValid)
            {
                var check = _food.InsertFood(model);
                if (check)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Alert = "خطای سمت سرور با پشتیبانی ارتباط برقرا ر کنید";
                    Meals(model.MealId); Sickness(model.SicknessId);
                    return View(model);
                }
            }
            else
            {

                Meals(model.MealId); Sickness(model.SicknessId);
                return View(model);
            }
        }

        [HttpGet]
        [Route("/Admin/Food/Edit/{id}")]
        public IActionResult Edit(string id)
        {
            var pageModel = _food.GetFoodById(id).Result;
            Meals(pageModel.MealId);
            Sickness(pageModel.SicknessId);
            return View(pageModel);
        }

        [HttpPost]
        [Route("/Admin/Food/Edit/{id}")]
        public IActionResult Edit(UpdateFoodViewModel model)
        {
            if (ModelState.IsValid)
            {
                var check = _food.UpdateFood(model);
                if (check)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Alert = "خطای سمت سرور با پشتیبانی ارتباط برقرا ر کنید";
                    Meals(model.MealId); Sickness(model.SicknessId);
                    return View(model);
                }
            }
            else
            {

                Meals(model.MealId); Sickness(model.SicknessId);
                return View(model);
            }
        }

        [HttpGet]
        [Route("/Admin/Food/Delete/{id}")]
        public bool Delete(string id)
        {
            return _food.DeleteFood(id);
        }



        [HttpGet]
        [Route("/Admin/Food/Gallery/{id}")]
        public IActionResult Gallery(string id)
        {
            ViewBag.Food = id;
            var pageModel = _gallery.GetImages(id).Result;
            return View(pageModel);
        }

        [HttpGet]
        [Route("/Admin/Gallery/Create")]
        public IActionResult CreateImage(string id)
        {
            ViewBag.Food = id;
            return View();
        }
        [HttpPost]
        [Route("/Admin/Gallery/Create")]
        public IActionResult CreateImage(InsertImageViewModel model)
        {
            if (ModelState.IsValid)
            {
                var check = _gallery.InsertImage(model);
                if (check)
                {
                    return RedirectToAction(nameof(Gallery), new { id = model.FoodId });
                }
                else
                {
                    ViewBag.Food = model.FoodId;
                    ViewBag.Alert = "خطای سمت سرور با پشتیبانی ارتباط برقرا ر کنید";
                    return View(model);
                }
            }
            else
            {
                ViewBag.Food = model.FoodId;
                return View(model);
            }
        }
        [HttpGet]
        [Route("/Admin/Gallery/Delete/{id}")]
        public bool DeleteImage(string id)
        {
            return _gallery.DeleteImage(id);
        }

        [HttpGet]
        [Route("/Admin/Food/Property/{id}")]
        public IActionResult Property(string id)
        {
            ViewBag.Food = id;
            var pageModel = _property.GetProperties(id).Result;
            return View(pageModel);
        }

        [HttpGet]
        [Route("/Admin/Property/Create")]
        public IActionResult CreateProperty(string id)
        {
            ViewBag.Food = id;
            return View();
        }

        [HttpPost]
        [Route("/Admin/Property/Create")]
        public IActionResult CreateProperty(InsertPropertyViewModel model)
        {
            if (ModelState.IsValid)
            {
                var check = _property.InsertProperty(model);
                if (check)
                {
                    return RedirectToAction(nameof(Property),new{id=model.FoodId});
                }
                else
                { 
                    ViewBag.Food = model.FoodId;
                    ViewBag.Alert = "خطای سمت سرور با پشتیبانی ارتباط برقرا ر کنید";
                    return View(model);
                }
            }
            else
            {
                ViewBag.Food = model.FoodId;
                return View(model);
            }
        }

        [HttpGet]
        [Route("/Admin/Property/Delete/{id}")]
        public bool DeleteProperty(string id)
        {
            return _property.DeleteProperty(id);
        }

        [HttpGet]
        [Route("/Admin/Food/Seo/{id}")]
        public IActionResult Seo(string id)
        {
            var pageModel = _food.GetSeoViewModel(id).Result;
            return View(pageModel);
        }
        [HttpPost]
        [Route("/Admin/Food/Seo/{id}")]
        public IActionResult Seo(FoodSeoViewModel model)
        {
            _food.ChangeSeo(model);
            return RedirectToAction(nameof(Seo), new { id = model.FoodId });
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





        [HttpGet]
        [Route("/Admin/Food/Comments")]
        public IActionResult Comments(string id, int page = 1, string search = "")
        {
            ViewBag.Id = id;
            ViewBag.Search = search;
            var pageModel = _food.GetComment(id, page, search ?? "");
            return View(pageModel);
        }

        [HttpGet]
        [Route("/Admin/Food/CommentDetail")]
        public IActionResult Detail(string id)
        {
            var pageModel = _food.GetCommentFoodDetail(id).Result;

            return View(pageModel);
        }

        [HttpPost]
        [Route("/Admin/Food/CommentDetail")]
        public IActionResult Detail(CommentFoodDetailViewModel model)
        {
            _food.UpdateComment(model);
            return RedirectToAction(nameof(Comments), new { id = model.ParentId });
        }

        [HttpGet]
        [Route("/Admin/Food/DeleteComment/{id}")]
        public void DeleteComment(string id)
        {
            _food.DeleteComment(id);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Service.Interface;
using Application.ViewModel.Category;

namespace Oghabian.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _category;

        public CategoryController(ICategoryService category)
        {
            _category = category;
        }
        [HttpGet]
        [Route("/Admin/Categories")]
        public IActionResult Index(int page = 1, string search = "")
        {
            ViewBag.Search = search;
            var pageModel = _category.GetCategories(page, search ?? "");
            return View(pageModel);
        }

        [HttpGet]
        [Route("/Admin/Category/Create")]
        public IActionResult Create()
        {
            ViewBag.Alert = null;
            return View();
        }
        [HttpPost]
        [Route("/Admin/Category/Create")]
        public IActionResult Create(InsertCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var check = _category.InsertCategory(model);
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
        [Route("/Admin/Category/Edit/{id}")]
        public IActionResult Edit(string id)
        {
            var pageModel = _category.GetCategoryById(id).Result;
            return View(pageModel);
        }

        [HttpPost]
        [Route("/Admin/Category/Edit/{id}")]
        public IActionResult Edit(UpdateCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var check = _category.UpdateCategory(model);
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
        [Route("/Admin/Category/Delete/{id}")]
        public bool Delete(string id)
        {
            return _category.DeleteCategory(id);
        }
    }
}

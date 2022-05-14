using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Service.Interface;
using Application.ViewModel.Slider;

namespace Oghabian.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly ISliderService _slider;

        public SliderController(ISliderService slider)
        {
            _slider = slider;
        }
        [HttpGet][Route("/Admin/Sliders")]
        public IActionResult Index()
        {
            var pageModel = _slider.GetImages().Result;
            return View(pageModel);
        }

        [HttpGet]
        [Route("/Admin/Slider/Create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Route("/Admin/Slider/Create")]
        public IActionResult Create(InsertSliderViewModel model)
        {
            if (ModelState.IsValid)
            {
                var check = _slider.InsertImage(model);
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
        [Route("/Admin/Slider/Delete/{id}")]
        public bool Delete(string id)
        {
            return _slider.DeleteImage(id);
        }
    }
}

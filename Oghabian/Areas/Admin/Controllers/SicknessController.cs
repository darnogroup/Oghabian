using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Service.Interface;
using Application.ViewModel.Sickness;

namespace Oghabian.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SicknessController : Controller
    {
        private readonly ISicknessService _sickness;

        public SicknessController(ISicknessService sickness)
        {
            _sickness = sickness;
        }
        [HttpGet][Route("/Admin/Sickness")]
        public IActionResult Index(int page=1,string search="")
        {
            ViewBag.Search = search;
            var pageModel = _sickness.GetSickness(page, search ?? "");
            return View(pageModel);
        }

        [HttpGet]
        [Route("/Admin/Sickness/Create")]
        public IActionResult Create()
        {
            ViewBag.Alert = null;
            return View();
        }
        [HttpPost]
          [Route("/Admin/Sickness/Create")]
        public IActionResult Create(InsertSicknessViewModel model)
        {
            if (ModelState.IsValid)
            {
                var check = _sickness.InsertSickness(model);
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
        [Route("/Admin/Sickness/Edit/{id}")]
        public IActionResult Edit(string id)
        {
            ViewBag.Alert = null;
            var pageModel = _sickness.GetSicknessById(id).Result;
            return View(pageModel);
        }

        [HttpPost]
        [Route("/Admin/Sickness/Edit/{id}")]
        public IActionResult Edit(UpdateSicknessViewModel model)
        {
            if (ModelState.IsValid)
            {
                var check = _sickness.UpdateSickness(model);
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
        [Route("/Admin/Sickness/Delete/{id}")]
        public bool Delete(string id)
        {
            return _sickness.DeleteSickness(id);
        }
    }
}

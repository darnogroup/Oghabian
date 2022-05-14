using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Service.Interface;
using Application.ViewModel.Supporter;

namespace Oghabian.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SupporterController : Controller
    {
        private readonly ISupporterService _supporter;

        public SupporterController(ISupporterService supporter)
        {
            _supporter = supporter;
        }

        [HttpGet]
        [Route("/Admin/Supporters")]
        public IActionResult Index(int page = 1, string search = "")
        {
            var pageModel = _supporter.GetSupporters(page, search ?? "");
            ViewBag.Search = search;
            return View(pageModel);
        }

        [HttpGet]
        [Route("/Admin/Supporter/Create")]
        public IActionResult Create()
        {
            return View();
        }  [HttpPost]
        [Route("/Admin/Supporter/Create")]
        public IActionResult Create(InsertSupporterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var check = _supporter.InsertSupporter(model);
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
        [Route("/Admin/Supporter/Edit/{id}")]
        public IActionResult Edit(string id)
        {
            var pageModel = _supporter.GetSupporterById(id).Result;
            return View(pageModel);
        }

        [HttpPost]
        [Route("/Admin/Supporter/Edit/{id}")]
        public IActionResult Edit(UpdateSupporterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var check = _supporter.UpdateSupporter(model);
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
        [Route("/Admin/Supporter/Delete/{id}")]
        public bool Delete(string id)
        {
            return _supporter.DeleteSupporter(id);
        }
    }

}


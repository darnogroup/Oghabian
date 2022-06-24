using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Service.Interface;
using Application.ViewModel.Link;

namespace Oghabian.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LinkController : Controller
    {
        private readonly ILinkService _link;

        public LinkController(ILinkService link)
        {
            _link = link;
        }
        [HttpGet][Route("/Admin/Links")]
        public IActionResult Index(int page=1,string search="")
        {
            ViewBag.Search = search;
            var pageModel = _link.GetLinks(page, search ?? "");
            return View(pageModel);
        }
        [HttpGet]
        [Route("/Admin/Link/Create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Route("/Admin/Link/Create")]
        public IActionResult Create(InsertLinkViewModel model)
        {
            if (ModelState.IsValid)
            {
                var check = _link.InsertLink(model);
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
        [Route("/Admin/Link/Edit/{id}")]
        public IActionResult Edit(string id)
        {
            var pageModel = _link.GetLinkById(id).Result;
            return View(pageModel);
        }

        [HttpPost]
        [Route("/Admin/Link/Edit/{id}")]
        public IActionResult Edit(UpdateLinkViewModel model)
        {
            if (ModelState.IsValid)
            {
                var check = _link.UpdateLink(model);
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
        [Route("/Admin/Link/Delete/{id}")]
        public bool Delete(string id)
        {
            return _link.DeleteLink(id);
        }
    }
}

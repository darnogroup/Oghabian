using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Service.Interface;
using Application.ViewModel.Discount;
using Application.ViewModel.Link;

namespace Oghabian.Areas.Admin.Controllers
{[Area("Admin")]
    public class DiscountController : Controller
    {
        private readonly IDiscountService _discount;

        public DiscountController(IDiscountService discount)
        {
            _discount = discount;
        }
        [HttpGet]
        [Route("/Admin/Discounts")]
        public IActionResult Index(int page = 1, string search = "")
        {
            ViewBag.Search = search;
            var pageModel = _discount.GetDiscounts(page, search ?? "");
            return View(pageModel);
        }
        [HttpGet]
        [Route("/Admin/Discount/Create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Route("/Admin/Discount/Create")]
        public IActionResult Create(InsertDiscountViewModel model)
        {
            if (ModelState.IsValid)
            {
                var check = _discount.InsertDiscount(model);
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
        [Route("/Admin/Discount/Edit/{id}")]
        public IActionResult Edit(string id)
        {
            var pageModel = _discount.GetDiscountById(id).Result;
            return View(pageModel);
        }

        [HttpPost]
        [Route("/Admin/Discount/Edit/{id}")]
        public IActionResult Edit(UpdateDiscountViewModel model)
        {
            if (ModelState.IsValid)
            {
                var check = _discount.UpdateDiscount(model);
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
        [Route("/Admin/Discount/Delete/{id}")]
        public bool Delete(string id)
        {
            return _discount.DeleteDiscount(id);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Service.Interface;
using Application.ViewModel.City;
using Application.ViewModel.State;

namespace Oghabian.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LocationController : Controller
    {
        private readonly IStateService _state;
        private readonly ICityService _city;

        public LocationController(IStateService state, ICityService city)
        {
            _state = state;
            _city = city;
        }
       
        [HttpGet][Route("/Admin/States")]
        public IActionResult Index(int page=1,string search="")
        {
            ViewBag.Search = search;
            var pageModel = _state.GetStates(page, search ?? "");
            return View(pageModel);
        }

        [HttpGet]
        [Route("/Admin/State/Create")]
        public IActionResult Create()
        {
            ViewBag.Alert = null;
            return View();
        }

        [HttpPost]
        [Route("/Admin/State/Create")]
        public IActionResult Create(InsertStateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var check = _state.InsertState(model);
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
        [Route("/Admin/State/Edit/{id}")]
        public IActionResult Edit(string id)
        {
            var pageModel = _state.GetStateById(id).Result;
            return View(pageModel);
        }

        [HttpPost]
        [Route("/Admin/State/Edit/{id}")]
        public IActionResult Edit(UpdateStateViewModel model)
        {

            if (ModelState.IsValid)
            {
                var check = _state.UpdateState(model);
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
        [Route("/Admin/State/Delete/{id}")]
        public bool Delete(string id)
        {
            return _state.DeleteState(id);
        }

        [HttpGet]
        [Route("/Admin/Cities")]
        public IActionResult Cities(string state, int page = 1, string search = "")
        {
            ViewBag.StateId = state;
            ViewBag.Search = search;
            var pageModel = _city.GetCities(state, page, search);
            return View(pageModel);
        }

        [HttpGet]
        [Route("/Admin/City/Create")]
        public IActionResult CreateCity(string stateId)
        {
            ViewBag.StateId = stateId;
            ViewBag.Alert = null;
            return View();
        }

        [HttpPost]
        [Route("/Admin/City/Create")]
        public IActionResult CreateCity(InsertCityViewModel model)
        {
            if (ModelState.IsValid)
            {
                var check = _city.InsertCity(model);
                if (check)
                {
                    return RedirectToAction(nameof(Cities), new {state = model.StateId});
                }
                else
                {
                    ViewBag.StateId = model.StateId;
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
        [Route("/Admin/City/Edit/{id}")]
        public IActionResult EditCity(string id)
        {
            var pageModel = _city.GetCityById(id).Result;
            return View(pageModel);
        }

        [HttpPost]
        [Route("/Admin/City/Edit/{id}")]
        public IActionResult EditCity(UpdateCityViewModel model)
        {
            if (ModelState.IsValid)
            {
                var check = _city.UpdateCity(model);
                if (check)
                {
                    return RedirectToAction(nameof(Cities), new { state = model.StateId });
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
        [Route("/Admin/City/Delete/{id}")]
        public bool DeleteCity(string id)
        {
            return _city.DeleteCity(id);
        }
    }
}

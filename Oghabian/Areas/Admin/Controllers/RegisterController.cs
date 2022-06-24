using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Service.Interface;

namespace Oghabian.Areas.Admin.Controllers
{[Area("Admin")]
    public class RegisterController : Controller
    {
        private readonly IRegisteredOrderService _registered;

        public RegisterController(IRegisteredOrderService registered)
        {
            _registered = registered;
        }
        [HttpGet][Route("/Admin/FoodRegister")]
        public IActionResult Register(int page=1,string search="")
        {
            ViewBag.Search = search;
            var pageModel = _registered.GetRegisters(page, search ?? "");
            return View(pageModel);
        }  


        [HttpGet][Route("/Admin/Close")]
        public IActionResult Close(int page=1,string search="")
        {
            ViewBag.Search = search;
            var pageModel = _registered.GetCloses(page, search ?? "");
            return View(pageModel);
        }
        
        

        [HttpGet][Route("/Admin/Kitchen")]
        public IActionResult Kitchen(int page=1,string search="")
        {
            ViewBag.Search = search;
            var pageModel = _registered.GetPreparations(page, search ?? "");
            return View(pageModel);
        }
        

        [HttpGet][Route("/Admin/Delivery")]
        public IActionResult Delivery(int page=1,string search="")
        {
            ViewBag.Search = search;
            var pageModel = _registered.GetDeliveries(page, search ?? "");
            return View(pageModel);
        }

        [HttpGet]
        [Route("/Admin/Detail/{id}")]
        public IActionResult Detail(string id)
        {
            var pageModel = _registered.GetDetailById(id);
            return View(pageModel);
        }
      
        [HttpGet]
        [Route("/Admin/DetailDelivery/{id}")]
        public IActionResult DetailDelivery(string id)
        {
            var pageModel = _registered.GetDetailById(id);
            return View(pageModel);
        }
        
        [HttpGet]
        [Route("/Admin/DetailClose/{id}")]
        public IActionResult DetailClose(string id)
        {
            var pageModel = _registered.GetDetailById(id);
            return View(pageModel);
        }
        [HttpGet]
        [Route("/Admin/DetailKitchen/{id}")]
        public IActionResult DetailKitchen(string id)
        {
            var pageModel = _registered.GetDetailById(id);
            return View(pageModel);
        }

        [HttpGet]
        [Route("/Admin/ReadyFood/{id}")]
        public void ReadyFood(string id)
        {
            _registered.KitchenFinish(id);
        }
         [HttpGet]
        [Route("/Admin/CloseOrder/{id}")]
        public void Close(string id)
        {
            _registered.Delivery(id);
        }


        [HttpGet]
        [Route("/Admin/AcceptFood/{id}")]
        public void AcceptFood(string id)
        {
             _registered.KitchenReady(id);
        }
        [HttpGet]
        [Route("/Admin/DeleteOrder/{id}")]
        public bool DeleteOrder(string id)
        {
            return _registered.DeleteOrder(id);
        }
    }
}

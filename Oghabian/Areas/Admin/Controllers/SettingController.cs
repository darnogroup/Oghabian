using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Service.Interface;
using Application.ViewModel.Setting;
using Microsoft.AspNetCore.Authorization;

namespace Oghabian.Areas.Admin.Controllers
{
    [Area("Admin")][Authorize(Roles = "Admin")]
    public class SettingController : Controller
    {
        private readonly ISettingService _setting;

        public SettingController(ISettingService setting)
        {
            _setting = setting;
        }
        [HttpGet][Route("/Admin/Setting")]
        public IActionResult Setting()
        {
            var pageModel = _setting.GetSettingViewModel().Result;
            return View(pageModel);
        }

        [HttpPost]
        [Route("/Admin/Setting")]
        public IActionResult Setting(SettingViewModel model)
        
        {
            _setting.ChangeSetting(model);
            return RedirectToAction(nameof(Setting));
        }



        [HttpGet]
        [Route("/Admin/Chats")]
        public IActionResult Chats()
        {
            return View();
        }
    }
}

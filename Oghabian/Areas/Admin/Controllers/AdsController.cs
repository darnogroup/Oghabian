using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Service.Interface;
using Application.ViewModel.Ads;

namespace Oghabian.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdsController : Controller
    {
        private readonly IAdsService _ads;

        public AdsController(IAdsService ads)
        {
            _ads = ads;
        }
        [HttpGet][Route("/Admin/Ads")]
        public IActionResult Ads()
        {
            var pageModel = _ads.GetAdsViewModel().Result;
            return View(pageModel);
        }  
        [HttpPost][Route("/Admin/Ads")]
        public IActionResult Ads(AdsViewModel model)
        {
            _ads.ChangeAds(model);
            return RedirectToAction(nameof(Ads));
        }
    }
}

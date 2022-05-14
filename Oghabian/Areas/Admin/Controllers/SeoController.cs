using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Service.Interface;
using Application.ViewModel.Seo;

namespace Oghabian.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SeoController : Controller
    {
        private readonly ISeoService _seo;

        public SeoController(ISeoService seo)
        {
            _seo = seo;
        }
        [HttpGet][Route("/Admin/Seo")]
        public IActionResult Seo()
        {
            var pageModel = _seo.GetSeoViewModel().Result;
            return View(pageModel);
        }  
        [HttpPost][Route("/Admin/Seo")]
        public IActionResult Seo(SeoViewModel model)
        {
            _seo.ChangeSeo(model);
            return RedirectToAction(nameof(Seo));
        }
    }
}

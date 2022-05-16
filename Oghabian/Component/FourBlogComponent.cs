using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Oghabian.Component
{
    public class FourBlogComponent:ViewComponent
    {
        private readonly IHomeService _home;

        public FourBlogComponent(IHomeService home)
        {
            _home = home;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var model = await _home.GetFourArticle();
            return View("/Views/Shared/ViewComponent/FourBlog.cshtml", model);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Oghabian.Component
{
    public class SeoArticleComponent:ViewComponent
    {
        private readonly IComponentService _component;

        public SeoArticleComponent(IComponentService component)
        {
            _component = component;
        }
        public async Task<IViewComponentResult> InvokeAsync(string id)
        {

            var model = await _component.GetSeoArticle(id);
            return View("/Views/Shared/ViewComponent/SeoArticle.cshtml", model);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Oghabian.Component
{
    public class ArticleCategoryComponent:ViewComponent
    {
        private readonly IComponentService _component;

        public ArticleCategoryComponent(IComponentService component)
        {
            _component = component;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var model =await _component.GetArticleCategories();
            return View("/Views/Shared/ViewComponent/ArticleCategory.cshtml", model);
        }
    }
}

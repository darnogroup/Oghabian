using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Oghabian.Component
{
    public class SeoFoodComponent:ViewComponent
    {
        private readonly IComponentService _component;

        public SeoFoodComponent(IComponentService component)
        {
            _component = component;
        }
        public async Task<IViewComponentResult> InvokeAsync(string id)
        {

            var model = await _component.GetSeoFood(id);
            return View("/Views/Shared/ViewComponent/SeoFood.cshtml", model);
        }
    }
}

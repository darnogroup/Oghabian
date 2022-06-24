using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Oghabian.Component
{
    public class SupporterComponent:ViewComponent
    {
        private readonly IComponentService _component;

        public SupporterComponent(IComponentService component)
        {
            _component = component;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var model = await _component.GetSupporters();
            return View("/Views/Shared/ViewComponent/Supporter.cshtml", model);
        }
    }
}

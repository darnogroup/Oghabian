using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Oghabian.Component
{
    public class LogoComponent:ViewComponent
    {
        private readonly IComponentService _component;

        public LogoComponent(IComponentService component)
        {
            _component = component;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var model = await _component.LogoPath();
            return View("/Views/Shared/ViewComponent/Logo.cshtml", model);
        }
    }
}

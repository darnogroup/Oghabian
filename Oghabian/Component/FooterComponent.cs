using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Oghabian.Component
{
    public class FooterComponent:ViewComponent
    {
        private readonly IComponentService _component;

        public FooterComponent(IComponentService component)
        {
            _component = component;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var model = await _component.GetFooter();
            return View("/Views/Shared/ViewComponent/Footer.cshtml", model);
        }
    }
}

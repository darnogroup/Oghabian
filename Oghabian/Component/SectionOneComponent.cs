using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Oghabian.Component
{
    public class SectionOneComponent:ViewComponent
    {
        private readonly IComponentService _component;

        public SectionOneComponent(IComponentService component)
        {
            _component = component;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var model = _component.GetSectionOne();
            return View("/Views/Shared/ViewComponent/SectionOne.cshtml", model);
        }
    }
}

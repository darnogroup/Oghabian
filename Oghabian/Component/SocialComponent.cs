using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Oghabian.Component
{
    public class SocialComponent:ViewComponent
    {
        private readonly IComponentService _component;

        public SocialComponent(IComponentService component)
        {
            _component = component;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var model =await _component.GetSocial();
            return View("/Views/Shared/ViewComponent/Social.cshtml", model);
        }
    }
}

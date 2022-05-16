using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Oghabian.Component
{
    public class SaidBarAdsComponent:ViewComponent
    {
        private readonly IComponentService _component;

        public SaidBarAdsComponent(IComponentService component)
        {
            _component = component;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var model =await _component.GetSaidBarAds();
            return View("/Views/Shared/ViewComponent/SaidBar.cshtml", model);
        }
    }
}

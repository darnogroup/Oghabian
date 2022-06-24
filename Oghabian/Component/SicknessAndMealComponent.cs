using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Oghabian.Component
{
    public class SicknessAndMealComponent:ViewComponent
    {

        private readonly IComponentService _component;

        public SicknessAndMealComponent(IComponentService component)
        {
            _component = component;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var model =  _component.GetSicknessAndMealMenu();
            return View("/Views/Shared/ViewComponent/sicknessandmeal.cshtml", model);
        }
    }
}

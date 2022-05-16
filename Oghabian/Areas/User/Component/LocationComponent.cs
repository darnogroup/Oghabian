using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Oghabian.Areas.User.Component
{
    public class LocationComponent:ViewComponent
    {
        private readonly IComponentService _component;

        public LocationComponent(IComponentService component)
        {
            _component = component;
        }
        public async Task<IViewComponentResult> InvokeAsync(string id)
        {

            var model = await _component.GetUserLocation(id);
            return View("~/Areas/User/Views/Shared/ViewComponent/Location.cshtml", model);
        }
    }
}

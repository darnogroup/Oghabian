using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Oghabian.Component
{
    public class CommentFoodComponent:ViewComponent
    {
        private readonly IComponentService _component;

        public CommentFoodComponent(IComponentService component)
        {
            _component = component;
        }
        public async Task<IViewComponentResult> InvokeAsync(string id)
        {

            var model = await _component.GetCommentFood(id);
            return View("/Views/Shared/ViewComponent/CommentFood.cshtml", model);
        }
    }
}

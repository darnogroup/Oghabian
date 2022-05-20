using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Application.Service.Interface;

namespace Oghabian.Areas.User.Controllers
{
    [Area("User")]
    public class OrderController : Controller
    {
        private readonly IProfileService _profile;

        public OrderController(IProfileService profile)
        {
            _profile = profile;
        }
        [HttpGet][Route("/Profile/OrderHistory")]
        public IActionResult OrderHistory()
        {
            var pageModel = _profile.OrderHistory(UserId()).Result;
            return View(pageModel);
        }
        [HttpGet][Route("/Profile/OrderHistoryDetail/{id}")]
        public IActionResult OrderHistoryDetail(string id)
        {
            var pageModel = _profile.GetDetail(id).Result;
            return View(pageModel);
        }
        public string UserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}

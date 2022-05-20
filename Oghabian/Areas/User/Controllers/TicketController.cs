using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Application.Service.Interface;
using Application.ViewModel.Home.Profile;

namespace Oghabian.Areas.User.Controllers
{
    [Area("User")]
    public class TicketController : Controller
    {
        private readonly IProfileService _profile;

        public TicketController(IProfileService profile)
        {
            _profile = profile;
        }
        [HttpGet][Route("/Profile/AddTicket")]
        public IActionResult Ticket()
        {
            ViewBag.User = UserId();
            return View();
        }

        [HttpPost]
        [Route("/Profile/AddTicket")]
        public IActionResult Ticket(AddTicketViewModel model)
        {
            if (ModelState.IsValid)
            {
                _profile.AddTicket(model);
                return Redirect("/profile");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        [Route("/Profile/Tickets")]
        public IActionResult AllTickets()
        {
            var pageModel = _profile.GetUserTicket(UserId()).Result;
            return View(pageModel);
        }

        [HttpGet]
        [Route("/Profile/Messages/{id}")]
        public IActionResult Messages(string id)
        {
            ViewBag.User = UserId(); ViewBag.Id = id;
            var pageModel = _profile.GetMessages(id).Result;
            return View(pageModel);
        }

        [HttpGet]
        [Route("/Profile/AddNewTicket/{id}")]
        public IActionResult AddNewTicket(string id)
        {
            ViewBag.Id = id; ViewBag.User = UserId();
            return View();
        }

        [HttpPost]
        [Route("/Profile/AddNewTicket/{id}")]
        public IActionResult AddNewTicket(AddNewTicketViewModel model)
        {
            if (ModelState.IsValid)
            {
                _profile.AddNewTicket(model);
                return Redirect("/profile");
            }
            else
            {
                return View(model);
            }
        }
     
        public string UserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Application.Service.Interface;
using Application.ViewModel.Ticket;

namespace Oghabian.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TicketController : Controller
    {
        private readonly ITicketService _ticket;

        public TicketController(ITicketService ticket)
        {
            _ticket = ticket;
        }
        [HttpGet][Route("/Admin/Tickets")]
        public IActionResult Index(int page = 1, string search = "")
        {
            ViewBag.Search = search;
            var pageModel = _ticket.GetTickets(page, search);
            return View(pageModel);
        }
        [HttpGet]
        [Route("/Admin/Ticket/Show/{id}")]
        public IActionResult Show(string id)
        {
            ViewBag.Id = id; ViewBag.User=UserId();
            var pageModel = _ticket.GetSubTickets(id).Result;
            return View(pageModel);
        }
        [HttpGet]
        [Route("/Admin/Ticket/CreateSub/{id}")]
        public IActionResult CreateSubTicket(string id)
        {
            ViewBag.Id = id;
           ViewBag.User= UserId(); 
            return View();
        }

        [HttpPost]
        [Route("/Admin/Ticket/CreateSub/{id}")]
        public IActionResult CreateSubTicket(InsertTicketDetailViewModel model)
        {
            if (ModelState.IsValid)
            {
                _ticket.CreateSubTicket(model);
                return RedirectToAction(nameof(Show), new { id = model.Id });
            }
            else
            {
                ViewBag.Id = model.Id;
                UserId();
                return View(model);
            }
        }
        public string UserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}

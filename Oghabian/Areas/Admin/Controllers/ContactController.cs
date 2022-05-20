using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Service.Interface;

namespace Oghabian.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly IContactService _contact;

        public ContactController(IContactService contact)
        {
            _contact = contact;
        }
        [HttpGet][Route("/Admin/Contacts")]
        public IActionResult Index(int page=1,string search="")
        {
            ViewBag.Search = search;
            var pageModel = _contact.GetMessages(page, search ?? "");
            return View(pageModel);
        }

        [HttpGet]
        [Route("/Admin/Contact/Detail")]
        public IActionResult Detail(string id)
        {
            var pageModel = _contact.GetMessageById(id).Result;
            return View(pageModel);
        }

        [HttpGet]
        [Route("/Admin/Contact/Delete/{id}")]
        public void Delete(string id)
        {
            _contact.DeleteMessage(id);
        }
    }
}

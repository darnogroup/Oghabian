using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Service.Interface;
using Application.ViewModel.Mail;

namespace Oghabian.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MailController : Controller
    {
        private readonly IMailService _mail;

        public MailController(IMailService mail)
        {
            _mail = mail;
        }
        [HttpGet][Route("/Admin/Mails")]
        public IActionResult Index(int page=1,string search="")
        {
            ViewBag.Search = search;
            var pageModel = _mail.GetMails(page, search ?? "");
            return View(pageModel);
        }

        [HttpGet]
        [Route("/Admin/Mail/Send")]
        public IActionResult Send()
        {
            return View();
        }
        [HttpPost]
        [Route("/Admin/Mail/Send")]
        public IActionResult Send(SendMailViewModel model)
        {
            if (ModelState.IsValid)
            {
                _mail.SendMail(model);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(model);
            }
        }
    }
}

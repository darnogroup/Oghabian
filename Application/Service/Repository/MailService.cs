using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Other;
using Application.Service.Interface;
using Application.ViewModel.Mail;
using Domin.Interfaces;

namespace Application.Service.Repository
{
    public class MailService:IMailService
    {
        private readonly IMailInterface _mail;
        private readonly ISenderService _sender;

        public MailService(IMailInterface mail, ISenderService sender)
        {
            _mail = mail;
            _sender = sender;
        }
        public Tuple<List<MailViewModel>, int, int> GetMails(int page, string search = "")
        {
            int pageSelected = page;
            int count =_mail.Count().PageCount(10);
            int pageSkip = (page - 1) * 10;
            var list =_mail.GetMails(search, pageSkip).Result;
            List<MailViewModel> mail = new List<MailViewModel>();

            foreach (var item in list)
            {
             mail.Add(new MailViewModel()
             {
                 Id = item.Id,Mail = item.Mail
             });
            }
            return Tuple.Create(mail, count, pageSelected);
        }

        public void SendMail(SendMailViewModel mail)
        {
            var list = _mail.GetAllMail().Result;
            foreach (var item in list)
            {
                _sender.SendMail(item.Mail,mail.Text,mail.Title);
            }
        }

        public void DeleteMail(string id)
        {
            var mail = _mail.GetMailById(id).Result;
            _mail.Delete(mail);
        }
    }
}

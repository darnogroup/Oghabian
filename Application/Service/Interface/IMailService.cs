using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModel.Mail;

namespace Application.Service.Interface
{
    public interface IMailService
    {
        Tuple<List<MailViewModel>, int, int> GetMails(int page, string search = "");
        void SendMail(SendMailViewModel mail);
        void DeleteMail(string id);
    }
}

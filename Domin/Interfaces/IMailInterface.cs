using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domin.Entities;

namespace Domin.Interfaces
{
    public interface IMailInterface
    {
        Task<List<MailEntity>> GetMails(string search, int skip);
        Task<MailEntity>GetMailById(string id);
        void Insert(MailEntity mail);
        void Delete(MailEntity mail);
        int Count();
        Task<List<MailEntity>> GetAllMail();

    }
}

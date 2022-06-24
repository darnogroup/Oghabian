using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Date.Context;
using Domin.Entities;
using Domin.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Date.Repositories
{
    public class MailRepository:IMailInterface
    {
        private readonly DataBaseContext _context;

        public MailRepository(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<List<MailEntity>> GetMails(string search, int skip)
        {
            return await _context.Mail.Where(w => w.Mail.ToLower().Contains(search)).Skip(skip).Take(10).ToListAsync();
        }

        public async Task<MailEntity> GetMailById(string id)
        {
            return await _context.Mail.FindAsync(id);
        }

        public void Insert(MailEntity mail)
        {
            _context.Mail.Add(mail);Save();
        }

        public void Delete(MailEntity mail)
        {
            _context.Mail.Remove(mail);Save();
        }

        public int Count()
        {
            return _context.Mail.Count();
        }

        public async Task<List<MailEntity>> GetAllMail()
        {
            return await _context.Mail.ToListAsync();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

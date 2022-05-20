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
    public class ContactRepository:IContactInterface
    {
        private readonly DataBaseContext _context;

        public ContactRepository(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ContactEntity>> GetContacts(string search, int skip)
        {
            return await _context.Contact.OrderByDescending(o => o.Time).Where(w => w.Name.ToLower().Contains(search))
                .Skip(skip).Take(10).ToListAsync();
        }

        public async Task<ContactEntity> GetContactById(string id)
        {
            return await _context.Contact.FindAsync(id);
        }

        public int Count()
        {
            return _context.Contact.Count();
        }

        public void Insert(ContactEntity contact)
        {
            _context.Contact.Add(contact);Save();
        }

        public void Update(ContactEntity contact)
        {
            _context.Update(contact);Save();
        }

        public void Remove(ContactEntity contact)
        {
            _context.Contact.Remove(contact);Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

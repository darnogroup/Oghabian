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
    public class LinkRepository:ILinkInterface
    {
        private readonly DataBaseContext _context;

        public LinkRepository(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<LinkEntity>> GetLinks(string search, int skip)
        {
            return await _context.Link.Where(w => w.LinkTitle.ToLower().Contains(search)).Skip(skip).Take(10)
                .ToListAsync();
        }

        public async Task<LinkEntity> GetLinkById(string id)
        {
            return await _context.Link.FindAsync(id);
        }

        public void InsertLink(LinkEntity link)
        {
            _context.Link.Add(link);
            Save();
        }

        public void UpdateLink(LinkEntity link)
        {
            _context.Update(link);Save();
        }

        public void DeleteLink(LinkEntity link)
        {
            _context.Link.Remove(link);Save();
        }

        public int CountLink()
        {
            return _context.Link.Count();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

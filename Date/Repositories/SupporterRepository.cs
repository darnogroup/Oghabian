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
    public class SupporterRepository:ISupporterInterface
    {
        private readonly DataBaseContext _context;

        public SupporterRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SupporterEntity>> GetSupporters(string search, int skip)
        {
            return await _context.Supporter.Where(w => w.SupporterName.ToLower().Contains(search))
                .Skip(skip).Take(10).ToListAsync();
        }

        public async Task<SupporterEntity> GetSupporterById(string id)
        {
            return await _context.Supporter.FindAsync(id);
        }

        public void InsertSupporter(SupporterEntity supporter)
        {
            _context.Supporter.Add(supporter);Save();
        }

        public void UpdateSupporter(SupporterEntity supporter)
        {
            _context.Update(supporter);Save();
        }

        public void DeleteSupporter(SupporterEntity supporter)
        {
            _context.Supporter.Remove(supporter);Save();
        }

        public int CountSupporter()
        {
            return _context.Supporter.Count();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

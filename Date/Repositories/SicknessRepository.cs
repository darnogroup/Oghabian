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
    public class SicknessRepository:ISicknessInterface
    {
        private readonly DataBaseContext _context;

        public SicknessRepository(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<SicknessEntity>> GetSickness(string search, int skip)
        {
            return await _context.Sickness.Where(w => w.SicknessTitle.ToLower().Contains(search))
                .Skip(skip).Take(10).ToListAsync();
        }

        public async Task<SicknessEntity> GetSicknessById(string id)
        {
            return await _context.Sickness.FindAsync(id);
        }

        public void InsertSickness(SicknessEntity sickness)
        {
            _context.Sickness.Add(sickness);Save();
        }

        public void UpdateSickness(SicknessEntity sickness)
        {
            _context.Update(sickness);Save();
        }

        public void DeleteSickness(SicknessEntity sickness)
        {
            _context.Sickness.Remove(sickness);Save();
        }

        public int CountSickness()
        {
            return _context.Sickness.Count();
        }

        public void Save()
        {
            _context.SaveChanges();

        }
    }
}

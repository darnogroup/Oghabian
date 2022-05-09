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
    public class SeoRepository:ISeoInterface
    {
        private readonly DataBaseContext _context;

        public SeoRepository(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<SeoEntity> GetSeo()
        {
            return await _context.Seo.FirstOrDefaultAsync();
        }

        public void Update(SeoEntity model)
        {
            _context.Update(model);Save();
        }

        public void Insert(SeoEntity model)
        {
            _context.Seo.Add(model);Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

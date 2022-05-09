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
    public class AdsRepository:IAdsInterface
    {
        private readonly DataBaseContext _context;

        public AdsRepository(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<AdsEntity> GetAds()
        {
            return await _context.Ads.FirstOrDefaultAsync();
        }

        public void Update(AdsEntity model)
        {
            _context.Update(model);Save();
        }

        public void Insert(AdsEntity model)
        {
            _context.Ads.Add(model);Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

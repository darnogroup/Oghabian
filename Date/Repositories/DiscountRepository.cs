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
    public class DiscountRepository:IDiscountInterface
    {
        private readonly DataBaseContext _context;

        public DiscountRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DiscountEntity>> GetDiscounts(string search, int skip)
        {
            return await _context.Discount.Where(w => w.DiscountTitle.ToLower().Contains(search)).ToListAsync();
        }

        public async Task<DiscountEntity> GetDiscountById(string id)
        {
            return await _context.Discount.FindAsync(id);
        }

        public void InsertDiscount(DiscountEntity discount)
        {
            _context.Discount.Add(discount);Save();
        }

        public void UpdateDiscount(DiscountEntity discount)
        {
            _context.Update(discount);Save();
        }

        public void DeleteDiscount(DiscountEntity discount)
        {
            _context.Discount.Remove(discount);Save();
        }

        public int CountDiscount()
        {
         return   _context.Discount.Count();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

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
    public class FoodRepository:IFoodInterface
    {
        private readonly DataBaseContext _context;

        public FoodRepository(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<FoodEntity>> GetFoods(string search, int skip)
        {
            return await _context.Food.OrderByDescending(o => o.Time)
                .Where(w => w.FoodTitle.ToLower().Contains(search))
                .Skip(skip).Take(10)
                .ToListAsync();
        }

        public async Task<FoodEntity> GetFoodById(string id)
        {
            return await _context.Food.FindAsync(id);
        }

        public void InsertFood(FoodEntity food)
        {
            _context.Food.Add(food);Save();
        }

        public void UpdateFood(FoodEntity food)
        {
            _context.Update(food);Save();
        }

        public void DeleteFood(FoodEntity food)
        {
            _context.Food.Remove(food);
        }

        public int CountFood()
        {
            return _context.Food.Count();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

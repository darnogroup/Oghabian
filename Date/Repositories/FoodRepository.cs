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
            _context.Food.Remove(food);Save();
        }

        public void DeleteSeo(FoodSeoEntity food)
        {
            _context.FoodSeo.Remove(food);Save();
        }

        public int CountFood()
        {
            return _context.Food.Count();
        }

        public async Task<FoodSeoEntity> GetSeo(string food)
        {
            return await _context.FoodSeo.SingleOrDefaultAsync(s => s.FoodId == food);
        }

        public void Update(FoodSeoEntity model)
        {
            _context.Update(model);Save();
        }

        public void Insert(FoodSeoEntity model)
        {
            _context.FoodSeo.Add(model);Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

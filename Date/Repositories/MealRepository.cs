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
    public class MealRepository:IMealInterface
    {
        private readonly DataBaseContext _context;

        public MealRepository(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<MealEntity>> GetMeals(string search, int skip)
        {
            return await _context.Meal.Where(w => w.MealTitle.ToLower().Contains(search))
                .Skip(skip).Take(10).ToListAsync();
        }

        public async Task<MealEntity> GetMealById(string id)
        {
            return await _context.Meal.FindAsync(id);
        }

        public void InsertMeal(MealEntity meal)
        {
            _context.Meal.Add(meal);Save();
        }

        public void UpdateMeal(MealEntity meal)
        {
            _context.Update(meal);Save();
        }

        public void DeleteMeal(MealEntity meal)
        {
            _context.Meal.Remove(meal);Save();
        }

        public int CountMeal()
        {
            return _context.Meal.Count();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

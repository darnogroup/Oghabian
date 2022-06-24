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
    public class FilterRepository:IFilterInterface
    {
        private readonly DataBaseContext _context;

        public FilterRepository(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<FoodEntity>> GetFoods(string search, int skip)
        {
            return await _context.Food.Where(w => w.FoodTitle.ToLower().Contains(search)).Include(i => i.Sickness).Skip(skip).Take(10).ToListAsync();
        }

        public async Task<IEnumerable<FoodEntity>> GetFoodsWithMeal(string meal, int skip)
        {
            return await _context.Food.Include(i => i.Sickness).Where(w => w.MealId == meal).Skip(skip).Take(10).ToListAsync();
        }

        public async Task<IEnumerable<FoodEntity>> GetFoodsWithMealAndSickness(string meal, string sickness, int skip)
        {
            return await _context.Food.Include(i => i.Sickness).Where(w => w.MealId == meal && w.SicknessId == sickness).Skip(skip).Take(10).ToListAsync();
        }

        public async Task<IEnumerable<FoodEntity>> GetFoodsWithMealAndFilter(string meal, int calories, string carbohydrate, string fat, string protein, int skip)
        {
            return await _context.Food.Include(i => i.Sickness).Where(w => w.MealId == meal && w.FoodCalories <= calories
                                                                                            && w.FoodFat == fat && w.FoodProtein == protein &&
                                                                                            w.FoodCarbohydrate == carbohydrate).Skip(skip).Take(10).ToListAsync();
        }

        public async Task<IEnumerable<FoodEntity>> GetFoodsWithSicknessAndFilter(string sickness, int calories, string carbohydrate, string fat, string protein, int skip)
        {
            return await _context.Food.Include(i => i.Sickness).Where(w => w.SicknessId == sickness && w.FoodCalories <= calories
                                                                                                    && w.FoodFat == fat && w.FoodProtein == protein &&
                                                                                                    w.FoodCarbohydrate == carbohydrate).Skip(skip).Take(10).ToListAsync();
        }

        public async Task<IEnumerable<FoodEntity>> GetFoodsFilter(string meal, string sickness, int calories, string carbohydrate, string fat, string protein,
            int skip)
        {
            return await _context.Food.Include(i => i.Sickness).Where(w => w.MealId == meal && w.SicknessId == sickness && w.FoodCalories <= calories
                                                                             && w.FoodFat == fat && w.FoodProtein == protein &&
                                                                             w.FoodCarbohydrate == carbohydrate).Skip(skip).Take(10).ToListAsync();
        }

        public async Task<IEnumerable<FoodEntity>> GetFoodsWithSickness(string sickness, int skip)
        {
            return await _context.Food.Include(i => i.Sickness).Where(w => w.SicknessId == sickness).Skip(skip).Take(10).ToListAsync();
        }

        public async Task<IEnumerable<FoodEntity>> GetFoodsWithFilter(int calories, string carbohydrate, string fat, string protein, int skip)
        {
            return await _context.Food.Include(i => i.Sickness).Where(w => w.FoodCalories <= calories
                                                                            && w.FoodFat == fat && w.FoodProtein == protein &&
                                                                            w.FoodCarbohydrate == carbohydrate).Skip(skip).Take(10).ToListAsync();
        }

        public int CountGetFoodsWithMeal(string meal)
        {
            return _context.Food.Count(w => w.MealId == meal);
        }

        public int CountGetFoodsWithMealAndSickness(string meal, string sickness)
        {
            return _context.Food.Count(w => w.MealId == meal && w.SicknessId == sickness);
        }

        public int CountGetFoodsWithMealAndFilter(string meal, int calories, string carbohydrate, string fat, string protein)
        {
            return _context.Food.Count(w => w.MealId == meal && w.FoodCalories <= calories
                                                             && w.FoodFat == fat && w.FoodProtein == protein &&
                                                             w.FoodCarbohydrate == carbohydrate);

        }

        public int CountGetFoodsWithSicknessAndFilter(string sickness, int calories, string carbohydrate, string fat,
            string protein)
        {

            return _context.Food.Count(w => w.SicknessId == sickness && w.FoodCalories <= calories
                                                             && w.FoodFat == fat && w.FoodProtein == protein &&
                                                             w.FoodCarbohydrate == carbohydrate);


        }

        public int CountGetFoodsFilter(string meal, string sickness, int calories, string carbohydrate, string fat, string protein)
        {
            return _context.Food.Count(w => w.SicknessId == sickness && w.FoodCalories <= calories
                                                                     && w.FoodFat == fat && w.FoodProtein == protein && w.MealId == meal &&
                                                                     w.FoodCarbohydrate == carbohydrate);
        }

        public int CountGetFoodsWithSickness(string sickness)
        {
            return _context.Food.Count(w => w.SicknessId == sickness);
        }

        public int CountGetFoodsWithFilter(int calories, string carbohydrate, string fat, string protein)
        {
            return _context.Food.Count(w => w.FoodCalories <= calories
                                                                     && w.FoodFat == fat && w.FoodProtein == protein &&
                                                                     w.FoodCarbohydrate == carbohydrate);
        }

        public int CountFood()
        {
            return _context.Food.Count();
        }

    }
}

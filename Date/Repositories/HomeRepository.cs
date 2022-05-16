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
    public class HomeRepository:IHomeInterface
    {
        private readonly DataBaseContext _context;

        public HomeRepository(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ArticleEntity>> GetFilterArticles(string category, string search, int skip)
        {
            return await _context.Article.Include(i=>i.Category)
                .Where(w => w.ArticleTitle.ToLower().Contains(search) && w.CategoryId == category)
                .Skip(skip).Take(10).ToListAsync();
        }

        public int CountFilterArticles(string category)
        {
            return _context.Article.Count(c=>c.CategoryId==category);
        }  
        public async Task<IEnumerable<ArticleEntity>> GetArticles (string search, int skip)
        {
            return await _context.Article.Include(i=>i.Category)
                .Where(w => w.ArticleTitle.ToLower().Contains(search))
                .Skip(skip).Take(10).ToListAsync();
        }

        public int CountArticles()
        {
            return _context.Article.Count();
        }

        public async Task<List<CategoryEntity>> GatCategories()
        {
            return await _context.Category.ToListAsync();
        }

        public async Task<ArticleEntity> GetArticleById(string id)
        {
            return await _context.Article.Include(i=>i.Category)
                .SingleOrDefaultAsync(s => s.ArticleId == id);
        }

        public async Task<IEnumerable<FoodEntity>> GetFoods(int skip)
        {
            return await _context.Food.Include(i=>i.Sickness).Skip(skip).Take(10).ToListAsync();
        }

        public async Task<IEnumerable<FoodEntity>> GetFoodsWithMeal(string meal, int skip)
        {
            return await _context.Food.Include(i => i.Sickness).Where(w => w.MealId == meal).Skip(skip).Take(10).ToListAsync();
        }

        public async Task<IEnumerable<FoodEntity>> GetFoodsWithMealAndSickness(string meal, string sickness, int skip)
        {
            return await _context.Food.Include(i => i.Sickness).Where(w => w.MealId == meal&&w.SicknessId==sickness).ToListAsync();
        }

        public async Task<IEnumerable<FoodEntity>> GetFoodsWithMealAndFilter(string meal, string calories, string carbohydrate, string fat, string protein, int skip)
        {
            return await _context.Food.Include(i => i.Sickness).Where(w => w.MealId == meal && w.FoodCalories == calories
                                                                                            && w.FoodFat == fat && w.FoodProtein == protein &&
                                                                                            w.FoodCarbohydrate == carbohydrate).Skip(skip).Take(10).ToListAsync();
        }

        public async Task<IEnumerable<FoodEntity>> GetFoodsWithSicknessAndFilter(string sickness, string calories, string carbohydrate, string fat, string protein, int skip)
        {
            return await _context.Food.Include(i => i.Sickness).Where(w => w.SicknessId == sickness && w.FoodCalories == calories
                                                                                                    && w.FoodFat == fat && w.FoodProtein == protein &&
                                                                                                    w.FoodCarbohydrate == carbohydrate).Skip(skip).Take(10).ToListAsync();
        }

        public async Task<IEnumerable<FoodEntity>> GetFoodsFilter(string meal, string sickness, string calories, string carbohydrate, string fat, string protein,
            int skip)
        {
            return await _context.Food.Include(i=>i.Sickness).Where(w =>w.MealId==meal&& w.SicknessId == sickness && w.FoodCalories == calories
                                                                           && w.FoodFat == fat && w.FoodProtein == protein &&
                                                                           w.FoodCarbohydrate == carbohydrate).Skip(skip).Take(10).ToListAsync();
        }

        public async Task<IEnumerable<FoodEntity>> GetFoodsWithSickness(string sickness, int skip)
        {
            return await _context.Food.Include(i => i.Sickness).Where(w => w.SicknessId == sickness).Skip(skip).Take(10).ToListAsync();
        }

        public async Task<IEnumerable<FoodEntity>> GetFoodsWithFilter(string calories, string carbohydrate, string fat, string protein, int skip)
        {
            return await _context.Food.Include(i => i.Sickness).Where(w =>  w.FoodCalories == calories
                                                                            && w.FoodFat == fat && w.FoodProtein == protein &&
                                                                            w.FoodCarbohydrate == carbohydrate).Skip(skip).Take(10).ToListAsync();
        }

        public int CountGetFoodsWithMeal(string meal)
        {
            return  _context.Food.Count(w => w.MealId == meal);
        }

        public int CountGetFoodsWithMealAndSickness(string meal, string sickness)
        {
            return  _context.Food.Count(w => w.MealId == meal && w.SicknessId == sickness);
        }

        public int CountGetFoodsWithMealAndFilter(string meal, string calories, string carbohydrate, string fat, string protein)
        {
            return  _context.Food.Count(w => w.MealId == meal && w.FoodCalories == calories
                                                              && w.FoodFat == fat && w.FoodProtein == protein &&
                                                              w.FoodCarbohydrate == carbohydrate);

        }

        public int CountGetFoodsWithSicknessAndFilter(string sickness, string calories, string carbohydrate, string fat,
            string protein)
        {

            return _context.Food.Count(w => w.SicknessId == sickness && w.FoodCalories == calories
                                                             && w.FoodFat == fat && w.FoodProtein == protein &&
                                                             w.FoodCarbohydrate == carbohydrate);


        }

        public int CountGetFoodsFilter(string meal, string sickness, string calories, string carbohydrate, string fat, string protein)
        {
            return _context.Food.Count(w => w.SicknessId == sickness && w.FoodCalories == calories
                                                                     && w.FoodFat == fat && w.FoodProtein == protein &&w.MealId==meal&&
                                                                     w.FoodCarbohydrate == carbohydrate);
        }

        public int CountGetFoodsWithSickness(string sickness)
        {
            return _context.Food.Count(w => w.SicknessId == sickness);
        }

        public int CountGetFoodsWithFilter(string calories, string carbohydrate, string fat, string protein)
        {
            return _context.Food.Count(w =>  w.FoodCalories == calories
                                                                     && w.FoodFat == fat && w.FoodProtein == protein &&
                                                                     w.FoodCarbohydrate == carbohydrate);
        }

        public int CountFood()
        {
            return _context.Food.Count();
        }

        public async Task<FoodEntity> GetFoodById(string id)
        {
            return await _context.Food.Include(i => i.Sickness).SingleOrDefaultAsync(s => s.FoodId == id);
        }

        public async Task<List<GalleryEntity>> GetGallery(string id)
        {
            return await _context.Gallery.Where(w => w.FoodId == id).ToListAsync();
        }

        public async Task<List<PropertyEntity>> GetProperty(string id)
        {
            return await _context.Property.Where(w => w.FoodId == id).ToListAsync();
        }

        public async Task<List<FoodEntity>> GetFoodTen()
        {
            return await _context.Food.Include(i => i.Sickness)
                .Take(10)   .ToListAsync();
        }

        public async Task<List<ArticleEntity>> GetFourArticle()
        {
            return await _context.Article.Include(i=>i.Category).Take(4).ToListAsync();
        }
    }
}

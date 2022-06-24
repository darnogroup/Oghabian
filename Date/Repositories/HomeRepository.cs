using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Date.Context;
using Domin.Entities;
using Domin.Enum;
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

        public async Task<IEnumerable<FoodEntity>> GetFoods(string search,int skip)
        {
            return await _context.Food.Where(w=>w.FoodTitle.ToLower().Contains(search)).Include(i=>i.Sickness).Skip(skip).Take(10).ToListAsync();
        }

        public async Task<IEnumerable<FoodEntity>> GetFoodsFilter(string meal, string sickness, int calories, string carbohydrate, string fat, string protein,
            int skip)
        {
            return await _context.Food.Include(i=>i.Sickness).Where(w => w.FoodCalories <=calories
                                                                        || w.FoodFat == fat || w.FoodProtein == protein ||
                                                                           w.FoodCarbohydrate == carbohydrate ||w.MealId == meal || w.SicknessId == sickness ).Skip(skip).Take(10).ToListAsync();
        }

        public async Task<IEnumerable<FoodEntity>> GetFoodForce(string meal, string sickness, int calories, string carbohydrate, string fat, string protein,
            WeekEnum week)
        {            return await _context.Food.Where(w => w.MealId == meal && w.SicknessId == sickness && w.FoodCalories <= calories
                                                                           && w.FoodFat == fat && w.FoodProtein == protein &&
                                                                           w.FoodCarbohydrate == carbohydrate && w.Day==week).ToListAsync();

        }

        public async Task<IEnumerable<FoodEntity>> GetFoodForceOther(string meal, string sickness, int calories, string carbohydrate, string fat, string protein, WeekEnum week)
        {
            return await _context.Food.Include(i => i.Sickness).Where(w => w.MealId == meal &&w.Day == week).ToListAsync();
        }


        public int CountGetFoodsFilter(string meal, string sickness, int calories, string carbohydrate, string fat, string protein)
        {
            return _context.Food.Count(w => w.SicknessId == sickness && Convert.ToInt32(w.FoodCalories) <= Convert.ToInt32(calories)
                                                                     && w.FoodFat == fat && w.FoodProtein == protein && w.MealId==meal &&
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

        public async Task<List<UserQuestionEntity>> UserQuestions()
        {
            return await _context.UserQuestion.OrderByDescending(o=>o.CreateTime).Include(i => i.User)
                .ToListAsync();
        }

        public async Task<List<UserAnswerEntity>> GetAnswer(string id)
        {
            return await _context.UserAnswer.OrderByDescending(o=>o.Time).Include(i => i.User)
                .Where(w=>w.QuestionId==id)
                .ToListAsync();
        }

        public void InsertQuestion(UserQuestionEntity question)
        {
            _context.UserQuestion.Add(question);Save();
        }

        public void InsertAnswer(UserAnswerEntity answer)
        {
            _context.UserAnswer.Add(answer);Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

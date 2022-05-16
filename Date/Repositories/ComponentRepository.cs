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
    public class ComponentRepository: IComponentInterface
    {
        private readonly DataBaseContext _context;

        public ComponentRepository(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<List<SliderEntity>> GetSlider()
        {
            return await _context.Slider.ToListAsync();
        }

        public async Task<AdsEntity> GetAds()
        {
            return await _context.Ads.FirstOrDefaultAsync();
        }

        public async Task<List<SicknessEntity>> GetSickness()
        {
            return await _context.Sickness.ToListAsync();
        }

        public  int GetFoodCount(string id)
        {
            return  _context.Food.Count(c => c.SicknessId == id);
        }

        public async Task<List<ArticleEntity>> GetLastArticles()
        {
            return await _context.Article.OrderByDescending(o => o.CreatedTime)
                .Take(4).ToListAsync();
        }

        public async Task<SettingEntity> GetSocial()
        {
            return await _context.Setting.FirstOrDefaultAsync();
        }

        public async Task<List<CommentArticleEntity>> GetArticleComments(string id)
        {
            return await _context.CommentArticle.Where(w => w.ArticleId == id&&w.Show==true)
                .Include(i => i.User).ToListAsync();
        }

        public async Task<List<CommentFoodEntity>> GetFoodComments(string id)
        {
            return await _context.CommentFood.Include(i => i.User).Where(w => w.FoodId == id && w.Show == true)
                .ToListAsync();
        }

        public async Task<ArticleSeoEntity> GetSeoArticleId(string id)
        {
            return await _context.ArticleSeo.SingleOrDefaultAsync(s => s.ArticleId == id);
        }

        public async Task<FoodSeoEntity> GetSeoFoodId(string id)
        {
            return await _context.FoodSeo.SingleOrDefaultAsync(s => s.FoodId == id);
        }

        public async Task<List<MealEntity>> GetMeals()
        {
            return await _context.Meal.ToListAsync();
        }

        public int GetMealCount(string id)
        {
            return _context.Food.Count(c => c.MealId == id);
        }
    }
}

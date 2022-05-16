using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domin.Entities;

namespace Domin.Interfaces
{
    public interface IComponentInterface
    {
        Task<List<SliderEntity>> GetSlider();
        Task<AdsEntity> GetAds();
        Task<List<SicknessEntity>> GetSickness();
        int GetFoodCount(string id);
        Task<List<ArticleEntity>> GetLastArticles();
        Task<SettingEntity> GetSocial();
        Task<List<CommentArticleEntity>> GetArticleComments(string id);
        Task<List<CommentFoodEntity>> GetFoodComments(string id);
        Task<ArticleSeoEntity> GetSeoArticleId(string id);
        Task<FoodSeoEntity> GetSeoFoodId(string id);
        Task<List<MealEntity>> GetMeals(); int GetMealCount(string id);
    }
}

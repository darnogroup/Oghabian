using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domin.Entities;
using Domin.Enum;

namespace Domin.Interfaces
{
    public interface IHomeInterface
    {
        Task<IEnumerable<ArticleEntity>> GetArticles(string search, int skip);
        int CountArticles();   
        Task<IEnumerable<ArticleEntity>> GetFilterArticles(string category, string search, int skip);
        int CountFilterArticles(string category);
        Task<List<CategoryEntity>> GatCategories();
        Task<ArticleEntity> GetArticleById(string id);
        Task<IEnumerable<FoodEntity>> GetFoods(string search,int skip);
       
        Task<IEnumerable<FoodEntity>> GetFoodsFilter(string meal, string sickness,int calories,string carbohydrate,string fat ,string protein, int skip);
        Task<IEnumerable<FoodEntity>> GetFoodForce(string meal, string sickness,int calories,string carbohydrate,string fat ,string protein, WeekEnum week);
        Task<IEnumerable<FoodEntity>> GetFoodForceOther(string meal, string sickness, int calories, string carbohydrate, string fat, string protein, WeekEnum week);

    
        int CountGetFoodsFilter(string meal, string sickness, int calories, string carbohydrate, string fat, string protein);

        int CountFood();

        Task<FoodEntity> GetFoodById(string id);
        Task<List<GalleryEntity>> GetGallery(string id);
        Task<List<PropertyEntity>> GetProperty(string id);
        Task<List<FoodEntity>> GetFoodTen();
        Task<List<ArticleEntity>> GetFourArticle();
        Task<List<UserQuestionEntity>> UserQuestions();
        Task<List<UserAnswerEntity>> GetAnswer(string id);
        void InsertQuestion(UserQuestionEntity question);
        void InsertAnswer(UserAnswerEntity answer);
    }
}

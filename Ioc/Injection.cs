using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Date.Repositories;
using Domin.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Ioc
{
    public class Injection
    {
        public static void Service(IServiceCollection service)
        {
            //Interfaces & Repositories
            service.AddScoped<IAdsInterface, AdsRepository>();
            service.AddScoped<IArticleInterface, ArticleRepository>();
            service.AddScoped<ICategoryInterface, CategoryRepository>();
            service.AddScoped<ICommentArticleInterface, CommentArticleRepository>();
            service.AddScoped<ICommentFoodInterface, CommentFoodRepository>();
            service.AddScoped<IFavoriteInterface, FavoriteRepository>();
            service.AddScoped<IFoodInterface, FoodRepository>();
            service.AddScoped<IGalleryInterface, GalleryRepository>();
            service.AddScoped<IMealInterface, MealRepository>();
            service.AddScoped<IPropertyInterface, PropertyRepository>();
            service.AddScoped<IQuestionInterface, QuestionRepository>();
            service.AddScoped<ISeoInterface, SeoRepository>();
            service.AddScoped<ISettingInterface, SettingRepository>();
            service.AddScoped<ISicknessInterface, SicknessRepository>();
            service.AddScoped<ISliderInterface, SliderRepository>();
            service.AddScoped<IUserInterface, UserRepository>();
        }
    }
}

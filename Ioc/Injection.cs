using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Service.Interface;
using Application.Service.Repository;
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
            service.AddScoped<IStateInterface, StateRepository>();
            service.AddScoped<ICityInterface, CityRepository>();
            service.AddScoped<IGeneralInterface,GeneralRepository>();
            service.AddScoped<ISupporterInterface,SupporterRepository>();
            service.AddScoped<IComponentInterface,ComponentRepository>();
            service.AddScoped<IHomeInterface,HomeRepository>();
            service.AddScoped<IProfileInterface,ProfileRepository>();
            service.AddScoped<IOrderInterface,OrderRepository>();
            //Services
            service.AddScoped<IMealService, MealService>();
            service.AddScoped<ISicknessService, SicknessService>();
            service.AddScoped<IStateService, StateService>();
            service.AddScoped<ICityService, CityService>();
            service.AddScoped<ICategoryService, CategoryService>();
            service.AddScoped<IArticleService, ArticleService>();
            service.AddScoped<IQuestionService, QuestionService>();
            service.AddScoped<IFoodService, FoodService>();
            service.AddScoped<IPropertyService, PropertyService>();
            service.AddScoped<IGalleryService, GalleryService>();
            service.AddScoped<IAdsService, AdsService>();
            service.AddScoped<ISeoService, SeoService>();
            service.AddScoped<ISettingService, SettingService>();
            service.AddScoped<ISliderService, SliderService>();
            service.AddScoped<ISupporterService, SupporterService>();
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IComponentService, ComponentService>();
            service.AddScoped<ISenderService, SenderService>();
            service.AddScoped<IHomeService, HomeService>();
            service.AddScoped<IProfileService, ProfileService>();
        }
    }
}

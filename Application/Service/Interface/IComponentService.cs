using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModel.Home;
using Application.ViewModel.Home.Blogs;
using Application.ViewModel.Home.Component;
using Application.ViewModel.Home.Foods;

namespace Application.Service.Interface
{
    public interface IComponentService
    {
        Tuple<List<SectionTwoRightViewModel>, SectionOneLeftViewModel> GetSectionOne();
        Task<List<SectionCategoryViewModel>> GetCategories();     
        Task<List<MealViewModel>> GetMeals();
        Task<List<CategoryViewModel>> GetArticleCategories();
        Task<List<LastArticleViewModel>> GetLastArticle();
        Task<SaidBarAdsViewModel> GetSaidBarAds();
        Task<SocialViewModel> GetSocial();
        Task<List<CommentArticleViewModel>> GetArticleComments(string id);
        Task<SeoArticleViewModel> GetSeoArticle(string id);
        Task<SeoFoodViewModel> GetSeoFood(string id);
        Task<List<CommentFoodViewModel>> GetCommentFood(string id);
        Task<LocationViewModel> GetUserLocation(string id);
        Task<ThreeBannerViewModel> GetThreeBanner();
        Task<SiteSeoViewModel> GetSeoSite();
    }
}

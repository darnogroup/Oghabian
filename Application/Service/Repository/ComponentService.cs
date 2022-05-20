using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Other;
using Application.Service.Interface;
using Application.ViewModel.Home;
using Application.ViewModel.Home.Blogs;
using Application.ViewModel.Home.Component;
using Application.ViewModel.Home.Foods;
using Domin.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Application.Service.Repository
{
    public class ComponentService : IComponentService
    {
        private readonly IComponentInterface _component;
        private readonly IHomeInterface _home;
        private readonly IProfileInterface _profile;
        private readonly ISeoInterface _seo;

        public ComponentService(IComponentInterface component, IHomeInterface home, IProfileInterface profile, ISeoInterface seo)
        {
            _component = component;
            _home = home;
            _profile = profile;
            _seo = seo;
        }
        public Tuple<List<SectionTwoRightViewModel>, SectionOneLeftViewModel> GetSectionOne()
        {
            var resultOne = _component.GetSlider().Result;
            List<SectionTwoRightViewModel> slider = new List<SectionTwoRightViewModel>();
            foreach (var item in resultOne)
            {
                slider.Add(new SectionTwoRightViewModel()
                {
                    SliderAlt = item.SliderAlt,
                    SliderPath = item.SliderImagePath
                });
            }

            var resultTwo = _component.GetAds().Result;
            SectionOneLeftViewModel ads = new SectionOneLeftViewModel();
            ads.ImageOne = resultTwo.ImageOne;
            ads.ImageOneAlt = resultTwo.ImageOneAlt;
            ads.ImageOneLink = resultTwo.ImageOneLink;
            ads.ImageTwo = resultTwo.ImageTwo;
            ads.ImageTwoAlt = resultTwo.ImageTwoAlt;
            ads.ImageTwoLink = resultTwo.ImageTwoLink;
            return Tuple.Create(slider, ads);
        }

        public async Task<List<SectionCategoryViewModel>> GetCategories()
        {
            var result = await _component.GetSickness();
            List<SectionCategoryViewModel> category=new List<SectionCategoryViewModel>();
            foreach (var item in result)
            {
                category.Add(new SectionCategoryViewModel()
                {
                    SectionCount = _component.GetFoodCount(item.SicknessId),
                    SectionId = item.SicknessId,
                    SectionPath = item.SicknessImagePath,
                    SectionTitle = item.SicknessTitle
                });
            }

            return category;
        }

        public async Task<List<MealViewModel>> GetMeals()
        {
            var result = await _component.GetMeals();
            List<MealViewModel> meal = new List<MealViewModel>();
            foreach (var item in result)
            {
                meal.Add(new MealViewModel()
                {
                    MealTitle = item.MealTitle,
                    MealCount = _component.GetMealCount(item.MealId),
                    MealId = item.MealId
                });
            }

            return meal;
        }

        public async Task<List<CategoryViewModel>> GetArticleCategories()
        {
            var result = await _home.GatCategories();
            List<CategoryViewModel> category = new List<CategoryViewModel>();
            foreach (var item in result)
            {
                category.Add(new CategoryViewModel()
                {
                    Count = _home.CountFilterArticles(item.CategoryId),
                    CategoryTitle = item.CategoryTitle,
                    CategoryId = item.CategoryId
                });
            }

            return category;
        }

        public async Task<List<LastArticleViewModel>> GetLastArticle()
        {
            var result = await _component.GetLastArticles();
            List<LastArticleViewModel>article=new List<LastArticleViewModel>();
            foreach (var item in result)
            {
                article.Add(new LastArticleViewModel()
                {
                    ArticleTitle = item.ArticleTitle,
                    ArticleId = item.ArticleId,
                    ArticlePath = item.ArticleImage,
                    CreateTime = item.CreatedTime.SolarYear()
                });
            }

            return article;
        }

        public async Task<SaidBarAdsViewModel> GetSaidBarAds()
        {
            var result = await _component.GetAds();
            SaidBarAdsViewModel saidBar=new SaidBarAdsViewModel();
            saidBar.ImageSidebarAlt = result.ImageSidebarAlt;
            saidBar.ImageSidebarLink = result.ImageSidebarLink;
            saidBar.ImageSidebar = result.ImageSidebar;
            return saidBar;
        }

        public async Task<SocialViewModel> GetSocial()
        {
            var result = await _component.GetSocial();
            SocialViewModel social=new SocialViewModel();
            social.FaceBook = result.FaceBook;
            social.Instagram = result.Instagram;
            social.Linkdin = result.Linkdin;
            social.WhatsApp = result.WhatsApp;
            return social;
        }

        public async Task<List<CommentArticleViewModel>> GetArticleComments(string id)
        {
            var result = await _component.GetArticleComments(id);
            List<CommentArticleViewModel>comments=new List<CommentArticleViewModel>();
            foreach (var item in result)
            {
                comments.Add(new CommentArticleViewModel()
                {
                    Avatar = item.User.UserAvatar,
                    Body = item.CommentBody,
                    Name = item.User.UserFullName,
                    Time = item.CreateTime.SolarYear()
                });
            }

            return comments;
        }

        public async Task<SeoArticleViewModel> GetSeoArticle(string id)
        {
           
            var result = await _component.GetSeoArticleId(id);
            SeoArticleViewModel seo=new SeoArticleViewModel();
            seo.GraphUrl = result.GraphUrl;
            seo.Description = result.Description;
            seo.GraphType = result.GraphType;
            seo.GraphDescription = result.GraphDescription;
            seo.GraphImagePath = result.GraphImage;
            seo.GraphTitle = result.GraphTitle;
            seo.GraphSiteName = result.GraphSiteName;
            seo.TwitterDescription = result.TwitterDescription;
            seo.TwitterImagePath = result.TwitterImage;
            seo.TwitterTitle = result.TwitterTitle;
            return seo;
      
        }

        public async Task<SeoFoodViewModel> GetSeoFood(string id)
        {

            var result = await _component.GetSeoFoodId(id);
            SeoFoodViewModel seo = new SeoFoodViewModel();
            seo.GraphUrl = result.GraphUrl;
            seo.Description = result.Description;
            seo.GraphType = result.GraphType;
            seo.GraphDescription = result.GraphDescription;
            seo.GraphImagePath = result.GraphImage;
            seo.GraphTitle = result.GraphTitle;
            seo.GraphSiteName = result.GraphSiteName;
            seo.TwitterDescription = result.TwitterDescription;
            seo.TwitterImagePath = result.TwitterImage;
            seo.TwitterTitle = result.TwitterTitle;
            return seo;
        }

        public async Task<List<CommentFoodViewModel>> GetCommentFood(string id)
        {
            var result = await _component.GetFoodComments(id);
            List<CommentFoodViewModel> comment=new List<CommentFoodViewModel>();
            foreach (var item in result)
            {
               comment.Add(new CommentFoodViewModel()
               {
                   Avatar = item.User.UserAvatar,
                   Body = item.CommentText,
                   Name = item.User.UserFullName,
                   Time = item.CreateTime.SolarYear()
               }); 
            }

            return comment;
        }

        public async Task<LocationViewModel> GetUserLocation(string id)
        {
            var location = await _profile.GetAddress(id);
            LocationViewModel model=new LocationViewModel();
            if (location != null)
            {
                model.State = location.State.StateName;
                model.Address = location.AddressText;
                model.Code = location.AddressCode;
                model.City = location.City.CityName;
            }
            else
            {
                model.State = "ثبت نشده";
                model.Address = "ثبت نشده";
                model.Code = "ثبت نشده";
                model.City = "ثبت نشده";
            }

            return model;
        }

        public  async Task<ThreeBannerViewModel> GetThreeBanner()
        {
            var result = await _component.GetAds();
            ThreeBannerViewModel ads=new ThreeBannerViewModel();
            ads.ImageHomeOne = result.ImageHomeOne;
            ads.ImageHomeOneAlt = result.ImageHomeOneAlt;
            ads.ImageHomeOneLink = result.ImageHomeOneLink;

            ads.ImageHomeTwo = result.ImageHomeTwo;
            ads.ImageHomeTwoAlt = result.ImageHomeTwoAlt;
            ads.ImageHomeTwoLink = result.ImageHomeTwoLink;

            ads.ImageHomeThree = result.ImageHomeThree;
            ads.ImageHomeThreeAlt = result.ImageHomeThreeAlt;
            ads.ImageHomeThreeLink = result.ImageHomeThreeLink;
            return ads;
        }

        public async Task<SiteSeoViewModel> GetSeoSite()
        {
            var result = await _seo.GetSeo();
            SiteSeoViewModel seo = new SiteSeoViewModel();
            seo.GraphUrl = result.GraphUrl;
            seo.GraphType = result.GraphType;
            seo.GraphDescription = result.GraphDescription;
            seo.GraphImagePath = result.GraphImage;
            seo.GraphTitle = result.GraphTitle;
            seo.GraphSiteName = result.GraphSiteName;
            seo.TwitterDescription = result.TwitterDescription;
            seo.TwitterImagePath = result.TwitterImage;
            seo.TwitterTitle = result.TwitterTitle;
            return seo;
        }
    }
}

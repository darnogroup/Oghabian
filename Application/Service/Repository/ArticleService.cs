using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Other;
using Application.Service.Interface;
using Application.ViewModel.Article;
using Application.ViewModel.Category;
using Application.ViewModel.Selection;
using Domin.Entities;
using Domin.Interfaces;

namespace Application.Service.Repository
{
    public class ArticleService:IArticleService
    {
        private readonly IArticleInterface _article;
        private readonly IGeneralInterface _general;

        public ArticleService(IArticleInterface article, IGeneralInterface general)
        {
            _article = article;
            _general = general;
        }
        public Tuple<List<ArticleViewModel>, int, int> GetArticles(int page, string search = "")
        {
            int pageSelected = page;
            int count = _article.CountArticle().PageCount(10);
            int pageSkip = (page - 1) * 10;
            var list =_article.GetArticles(search, pageSkip).Result;
            List<ArticleViewModel> article = new List<ArticleViewModel>();

            foreach (var item in list)
            {
                article.Add(new ArticleViewModel()
                {
                    ArticleTitle = item.ArticleTitle,
                    ArticleId = item.ArticleId,
                    ArticleImage = item.ArticleImage,
                    VisitCount = item.VisitCount,
                    CreateTime = item.CreatedTime.SolarYear()
                });
            }
            return Tuple.Create(article, count, pageSelected);
        }

        public async Task<UpdateArticleViewModel> GetArticleById(string id)
        {
            var result = await _article.GetArticleById(id);
            UpdateArticleViewModel article=new UpdateArticleViewModel();
            article.CategoryId = result.CategoryId;
            article.ArticleId = result.ArticleId;
            article.ArticleImagePath = result.ArticleImage;
            article.ArticleBody = result.ArticleBody;
            article.ArticleTags = result.ArticleTags;
            article.ArticleTitle = result.ArticleTitle;
            article.TimeStudy = result.TimeStudy;
            return article;
        }

        public bool InsertArticle(InsertArticleViewModel model)
        {
            ArticleEntity article=new ArticleEntity();
            article.CategoryId = model.CategoryId;
            article.ArticleBody = model.ArticleBody;
            article.ArticleTags = model.ArticleTags;
            article.ArticleTitle = model.ArticleTitle;
            article.TimeStudy = model.TimeStudy;
            article.CreatedTime=DateTime.Now;
            if (model.ArticleImage != null)
            {
                var check = model.ArticleImage.IsImage();
                if (check)
                {
                    article.ArticleImage = ImageProcessing.SaveImage(model.ArticleImage);
                }
                else
                {
                    article.ArticleImage= "notFound.png";
                }
            }
            else
            {
                article.ArticleImage = "notFound.png";
            }

            try
            {
                _article.InsertArticle(article);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateArticle(UpdateArticleViewModel model)
        {
            var article = _article.GetArticleById(model.ArticleId).Result;
            article.CategoryId = model.CategoryId;
            article.ArticleBody = model.ArticleBody;
            article.ArticleTags = model.ArticleTags;
            article.ArticleTitle = model.ArticleTitle;
            article.TimeStudy = model.TimeStudy;
            if (model.ArticleImage != null)
            {
                var check = model.ArticleImage.IsImage();
                if (check)
                {
                    article.ArticleImage = ImageProcessing.SaveImage(model.ArticleImage);
                    if (model.ArticleImagePath != "notFound.png")
                    {
                        ImageProcessing.RemoveImage(model.ArticleImagePath);
                    }
                }
            }

            try
            {
                _article.UpdateArticle(article);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteArticle(string id)
        {
            var article = _article.GetArticleById(id).Result;
            try
            {
                _article.DeleteArticle(article);
                if (article.ArticleImage != "notFound.png")
                {
                    ImageProcessing.RemoveImage(article.ArticleImage);
                }

                return true;
            }
            catch 
            {
                return false;
            }
        }

        public async Task<List<SelectViewModel>> GetCategories()
        {
            var result = await _general.GetCategories();
            List<SelectViewModel>select=new List<SelectViewModel>();
            foreach (var item in result)
            {
                select.Add(new SelectViewModel()
                {
                    Text = item.CategoryTitle,
                    Value = item.CategoryId
                });
            }

            return select;
        }
    }
}

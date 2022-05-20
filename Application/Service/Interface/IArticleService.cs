using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModel.Article;
using Application.ViewModel.Selection;

namespace Application.Service.Interface
{
    public interface IArticleService
    {
        Tuple<List<ArticleViewModel>, int, int> GetArticles(int page, string search = "");
        Task<UpdateArticleViewModel> GetArticleById(string id);
        bool InsertArticle(InsertArticleViewModel model);
        bool UpdateArticle(UpdateArticleViewModel model);
        bool DeleteArticle(string id);
        Task<List<SelectViewModel>> GetCategories();
        Task<ArticleSeoViewModel> GetSeoViewModel(string id);
        void ChangeSeo(ArticleSeoViewModel model);
        Tuple<List<CommentArticleViewModel>, int, int> GetComment(string id, int page = 1, string search = "");
        Task<CommentArticleDetailViewModel> GetCommentArticleDetail(string id);
        void UpdateComment(CommentArticleDetailViewModel model);
        void DeleteComment(string id);
    }
}

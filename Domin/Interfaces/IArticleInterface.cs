using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domin.Entities;

namespace Domin.Interfaces
{
    public interface IArticleInterface
    {
        Task<IEnumerable<ArticleEntity>> GetArticles(string search, int skip);
        Task<ArticleEntity> GetArticleById(string id);
        void InsertArticle(ArticleEntity article);
        void UpdateArticle(ArticleEntity article);
        void DeleteArticle(ArticleEntity article);
        void DeleteSeoArticle(ArticleSeoEntity article);
        int CountArticle();
  
     Task<ArticleSeoEntity> GetSeo( string article);
        void Update(ArticleSeoEntity model);
        void Insert(ArticleSeoEntity model);
    }
}

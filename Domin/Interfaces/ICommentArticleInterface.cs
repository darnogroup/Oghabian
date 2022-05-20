using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domin.Entities;

namespace Domin.Interfaces
{
    public interface ICommentArticleInterface
    {
        Task<IEnumerable<CommentArticleEntity>> GetCommentArticles(string parentId,string search, int skip);
        Task<CommentArticleEntity> GetCommentArticleById(string id);
        void InsertCommentArticle(CommentArticleEntity commentArticle);
        void UpdateCommentArticle(CommentArticleEntity commentArticle);
        void DeleteCommentArticle(CommentArticleEntity commentArticle);
        int CountCommentArticle(string id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Date.Context;
using Domin.Entities;
using Domin.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Date.Repositories
{
    public class CommentArticleRepository:ICommentArticleInterface
    {
        private readonly DataBaseContext _context;

        public CommentArticleRepository(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CommentArticleEntity>> GetCommentArticles(string parentId,string search, int skip)
        {
            return await _context.CommentArticle.OrderByDescending(o => o.CreateTime)
                .Where(w => w.CommentBody.ToLower().Contains(search) && w.ArticleId == parentId).Skip(skip)
                .Take(10).ToListAsync();
        }

        public async Task<CommentArticleEntity> GetCommentArticleById(string id)
        {
            return await _context.CommentArticle.FindAsync(id);
        }

        public void InsertCommentArticle(CommentArticleEntity commentArticle)
        {
            _context.CommentArticle.Add(commentArticle);Save();
        }

        public void UpdateCommentArticle(CommentArticleEntity commentArticle)
        {
            _context.Update(commentArticle); Save();
        }

        public void DeleteCommentArticle(CommentArticleEntity commentArticle)
        {
            _context.CommentArticle.Remove(commentArticle);Save();
        }

        public int CountCommentArticle()
        {
            return _context.CommentArticle.Count();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

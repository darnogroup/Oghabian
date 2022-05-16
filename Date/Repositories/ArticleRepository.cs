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
    public class ArticleRepository:IArticleInterface
    {
        private readonly DataBaseContext _context;

        public ArticleRepository(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ArticleEntity>> GetArticles(string search, int skip)
        {
            return await _context.Article.OrderByDescending(o => o.CreatedTime)
                .Where(w => w.ArticleTitle.ToLower().Contains(search)).Skip(skip).Take(10)
                .ToListAsync();
        }

      
        public async Task<ArticleEntity> GetArticleById(string id)
        {
            return await _context.Article.FindAsync(id);
        }

        public void InsertArticle(ArticleEntity article)
        {
            _context.Article.Add(article);Save();
        }

        public void UpdateArticle(ArticleEntity article)
        {
            _context.Update(article);Save();
        }

        public void DeleteArticle(ArticleEntity article)
        {
            _context.Article.Remove(article);Save();
        }

        public void DeleteSeoArticle(ArticleSeoEntity article)
        {
            _context.ArticleSeo.Remove(article);Save();
        }

        public int CountArticle()
        {
            return _context.Article.Count();
        }

        public async Task<ArticleSeoEntity> GetSeo(string article)
        {
            return await _context.ArticleSeo.SingleOrDefaultAsync(s => s.ArticleId == article);
        }

        public void Update(ArticleSeoEntity model)
        {
            _context.Update(model);Save();
        }

        public void Insert(ArticleSeoEntity model)
        {
            _context.ArticleSeo.Add(model);Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

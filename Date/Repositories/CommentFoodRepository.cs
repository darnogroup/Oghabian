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
    public class CommentFoodRepository:ICommentFoodInterface
    {
        private readonly DataBaseContext _context;

        public CommentFoodRepository(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CommentFoodEntity>> GetCommentFoods(string parentId, string search, int skip)
        {
            return await _context.CommentFood.OrderByDescending(o => o.CreateTime).Include(i=>i.User)
                .Where(w => w.CommentText.ToLower().Contains(search) && w.FoodId == parentId).Skip(skip)
                .Take(10).ToListAsync();
        }


        public async Task<CommentFoodEntity> GetCommentFoodById(string id)
        {
            return await _context.CommentFood.Include(i => i.User).SingleOrDefaultAsync(s => s.CommentId == id);
        }

        public void InsertCommentFood(CommentFoodEntity commentFood)
        {
            _context.CommentFood.Add(commentFood); Save();
        }

        public void UpdateCommentFood(CommentFoodEntity commentFood)
        {
            _context.Update(commentFood); Save();
        }

        public void DeleteCommentFood(CommentFoodEntity commentFood)
        {
            _context.CommentFood.Remove(commentFood); Save();
        }

        public int CountCommentFood(string id)
        {
            return _context.CommentFood.Count(c=>c.FoodId==id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

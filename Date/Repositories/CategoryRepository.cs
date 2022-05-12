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
    public class CategoryRepository:ICategoryInterface
    {
        private readonly DataBaseContext _context;

        public CategoryRepository(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CategoryEntity>> GetCategories(string search, int skip)
        {
            return await _context.Category.Where(w => w.CategoryTitle.ToLower().Contains(search))
                .Skip(skip).Take(10).ToListAsync();
        }

        public async Task<CategoryEntity> GetCategoryById(string id)
        {
            return await _context.Category.FindAsync(id);
        }

        public void InsertCategory(CategoryEntity category)
        {
            _context.Category.Add(category);Save();
        }

        public void UpdateCategory(CategoryEntity category)
        {
            _context.Update(category);Save();
        }

        public void DeleteCategory(CategoryEntity category)
        {
            _context.Category.Remove(category);Save();
        }

        public int CountCategory()
        {
            return  _context.Category.Count();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

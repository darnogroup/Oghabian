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
    public class GeneralRepository:IGeneralInterface
    {
        private readonly DataBaseContext _context;

        public GeneralRepository(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<List<CategoryEntity>> GetCategories()
        {
            return await _context.Category.ToListAsync();
        }

        public async Task<List<MealEntity>> GetMeals()
        {
            return await _context.Meal.ToListAsync();
        }

        public async Task<List<SicknessEntity>> GetSickness()
        {
            return await _context.Sickness.ToListAsync();
        }
    }
}

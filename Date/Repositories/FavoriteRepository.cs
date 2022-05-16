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
    public class FavoriteRepository:IFavoriteInterface
    {
        private readonly DataBaseContext _context;

        public FavoriteRepository(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<FavoriteEntity>> GetFavorites(string userId, int skip)
        {
            return await _context.Favorite.Where(w => w.UserId == userId)
                .Skip(10).Take(10).ToListAsync();
        }

        public async Task<FavoriteEntity> GetFavoriteById(string id)
        {
            return await _context.Favorite.FindAsync(id);
        }

        public void InsertFavorite(FavoriteEntity favorite)
        {
            _context.Favorite.Add(favorite);Save();
        }

        public void UpdateFavorite(FavoriteEntity favorite)
        {
            _context.Update(favorite);Save();
        }

        public void DeleteFavorite(FavoriteEntity favorite)
        {
            _context.Favorite.Remove(favorite);Save();
        }

        public int CountFavorite()
        {
         return   _context.Favorite.Count();
        }

    

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

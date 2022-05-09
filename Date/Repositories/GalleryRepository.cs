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
    public class GalleryRepository:IGalleryInterface
    {
        private readonly DataBaseContext _context;

        public GalleryRepository(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<GalleryEntity>> GetGalleries(string parentId)
        {
            return await _context.Gallery.Where(w => w.FoodId == parentId).ToListAsync();
        }

        public async Task<GalleryEntity> GetGalleryById(string id)
        {
            return await _context.Gallery.FindAsync(id);
        }

        public void InsertGallery(GalleryEntity gallery)
        {
            _context.Gallery.Add(gallery);Save();
        }

        public void DeleteGallery(GalleryEntity gallery)
        {
            _context.Gallery.Remove(gallery);Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

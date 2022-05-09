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
    public class PropertyRepository:IPropertyInterface
    {
        private readonly DataBaseContext _context;

        public PropertyRepository(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<PropertyEntity>> GetProperties(string parent)
        {
            return await _context.Property.Where(w => w.FoodId == parent).ToListAsync();
        }

        public async Task<PropertyEntity> GetPropertyById(string id)
        {
            return await _context.Property.FindAsync(id);
        }

        public void InsertProperty(PropertyEntity property)
        {
            _context.Property.Add(property);Save();
        }

        public void DeleteProperty(PropertyEntity property)
        {
            _context.Property.Remove(property);Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

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
    public class CityRepository:ICityInterface
    {
        private readonly DataBaseContext _context;

        public CityRepository(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CityEntity>> GetCities(string stateId, string search, int skip)
        {
            return await _context.City.Where(w => w.StateId == stateId && w.CityName.ToLower().Contains(search))
                .Skip(skip).Take(10).ToListAsync();
        }

        public async Task<CityEntity> GetCityById(string id)
        {
            return await _context.City.FindAsync(id);
        }

        public void InsertCity(CityEntity city)
        {
            _context.City.Add(city);Save();
        }

        public void UpdateCity(CityEntity city)
        {
            _context.Update(city);Save();
        }

        public void DeleteCity(CityEntity city)
        {
            _context.City.Remove(city);
            Save();
        }

        public int CountCity(string stateId)
        {
            return _context.City.Count(c => c.StateId == stateId);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

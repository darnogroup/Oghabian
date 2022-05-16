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
    public class ProfileRepository:IProfileInterface
    {
        private readonly DataBaseContext _context;

        public ProfileRepository(DataBaseContext context)
        {
            _context = context;
        }


        public async Task<List<StateEntity>> GetState()
        {
            return await _context.State.ToListAsync();
        }

        public async Task<List<CityEntity>> GetCities(string state)
        {
            return await _context.City.Where(w => w.StateId == state).ToListAsync();
        }

        public async Task<AddressEntity> GetAddress(string user)
        {
            return await _context.Address.Include(i=>i.City)
                .Include(i=>i.State).SingleOrDefaultAsync(s => s.UserId == user);
        }

        public void InsertAddress(AddressEntity address)
        {
            _context.Address.Add(address);Save();
        }

        public void UpdateAddress(AddressEntity address)
        {
            _context.Update(address); Save();
        }

        public async Task<List<FavoriteEntity>> GetFavorites(string id)
        {
            return await _context.Favorite.Include(i => i.Food).Where(w => w.UserId == id)
                .ToListAsync();
        }

        public void AddFavorite(FavoriteEntity favorite)
        {
            _context.Favorite.Add(favorite);Save();
        }

        public void DeleteFavorite(FavoriteEntity favorite)
        {
            _context.Favorite.Remove(favorite);Save();
        }

        public async Task<FavoriteEntity> GetFavoriteById(string id)
        {
            return await _context.Favorite.FindAsync(id);
        }
        public async Task<MedicalInformationEntity> GetMedicalInformation(string id)
        {
            return await _context.MedicalInformation.Where(w => w.UserId == id)
                .SingleOrDefaultAsync();
        }

        public void Update(MedicalInformationEntity model)
        {
            _context.Update(model); Save();
        }

        public void Insert(MedicalInformationEntity model)
        {
            _context.MedicalInformation.Add(model); Save();
        }
        public bool Exist(string user, string food)
        {
            return _context.Favorite.Any(a => a.UserId == user && a.FoodId == food);
        }

        public async Task<string> SenPrice()
        {
            return await _context.Setting.Select(s=>s.SendPrice).SingleOrDefaultAsync();
        }

        public async Task<string> FullName(string id)
        {
            return await _context.Users.Select(s => s.UserFullName).SingleOrDefaultAsync();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

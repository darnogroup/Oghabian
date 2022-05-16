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
    public class UserRepository:IUserInterface
    {
        private readonly DataBaseContext _context;

        public UserRepository(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<UserEntity>> GetUsers(string search, int skip)
        {
            return await _context.Users.OrderByDescending(o => o.Time)
                .Where(w => w.UserFullName.ToLower().Contains(search))
                .Skip(skip).Take(10).ToListAsync();
        }

        public int CountUser()
        {
            return _context.Users.Count();
        }

        public async Task<UserEntity> GetUserByNumber(string number, string code)
        {
            return await _context.Users.Where(w => w.LoginCode == code && w.PhoneNumber == number)
                .SingleOrDefaultAsync();
        }

        public async Task<UserEntity> FindUserByNumber(string number)
        {
            return await _context.Users.Where(w => w.PhoneNumber == number)
                .SingleOrDefaultAsync();
        }

        public void UpdateUser(UserEntity user)
        {
            _context.Update(user);Save();
        }

        public async Task<MedicalInformationEntity> GetMedicalInformation(string id)
        {
            return await _context.MedicalInformation.Where(w => w.UserId == id)
                .SingleOrDefaultAsync();
        }

        public void Update(MedicalInformationEntity model)
        {
            _context.Update(model);Save();
        }

        public void Insert(MedicalInformationEntity model)
        {
            _context.MedicalInformation.Add(model);Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

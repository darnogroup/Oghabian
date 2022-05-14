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
    public class SettingRepository:ISettingInterface
    {
        private readonly DataBaseContext _context;

        public SettingRepository(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<SettingEntity> GetSetting()
        {
            return await _context.Setting.FirstOrDefaultAsync();
        }

        public void Update(SettingEntity model)
        {
            _context.Update(model);Save();
        }

        public void Insert(SettingEntity model)
        {
            _context.Setting.Add(model); Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

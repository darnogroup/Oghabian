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
    public class SliderRepository:ISliderInterface
    {
        private readonly DataBaseContext _context;

        public SliderRepository(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<SliderEntity>> GetSliders()
        {
            return await _context.Slider.ToListAsync();
        }

        public async Task<SliderEntity> GetSliderById(string id)
        {
            return await _context.Slider.FindAsync(id);
        }

        public void InsertSlider(SliderEntity slider)
        {
            _context.Slider.Add(slider);
            Save();
        }

        public void DeleteSlider(SliderEntity slider)
        {
            _context.Slider.Remove(slider);Save();
        }


        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

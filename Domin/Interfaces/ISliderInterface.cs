using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domin.Entities;

namespace Domin.Interfaces
{
    public interface ISliderInterface
    {
        Task<IEnumerable<SliderEntity>> GetSliders();
        Task<SliderEntity> GetSliderById(string id);
        void InsertSlider(SliderEntity slider);
        void DeleteSlider(SliderEntity slider);
   
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModel.Slider;

namespace Application.Service.Interface
{
    public interface ISliderService
    {
        Task<List<SliderViewModel>> GetImages();
        bool InsertImage(InsertSliderViewModel model);
        bool DeleteImage(string id);
    }
}

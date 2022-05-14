using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Other;
using Application.Service.Interface;
using Application.ViewModel.Slider;
using Domin.Entities;
using Domin.Interfaces;

namespace Application.Service.Repository
{
    public class SliderService:ISliderService
    {
        private readonly ISliderInterface _slider;

        public SliderService(ISliderInterface slider)
        {
            _slider = slider;
        }
        public async Task<List<SliderViewModel>> GetImages()
        {
            var result = await _slider.GetSliders();
            List<SliderViewModel>slider=new List<SliderViewModel>();
            foreach (var item in result)
            {
                slider.Add(new SliderViewModel()
                {
                    SliderImagePath = item.SliderImagePath,
                    SliderId = item.SliderId,
                    SliderAlt = item.SliderAlt
                });
            }

            return slider;
        }

        public bool InsertImage(InsertSliderViewModel model)
        {
            SliderEntity slider=new SliderEntity();
            if (model.SliderImageFile != null)
            {
                var check = model.SliderImageFile.IsImage();
                if (check)
                {
                   slider.SliderImagePath = ImageProcessing.SaveImage(model.SliderImageFile);
                }
                else
                {
                    slider.SliderImagePath = "notFound.png";
                }
            }
            else
            {
                slider.SliderImagePath = "notFound.png";
            }

            slider.SliderAlt = model.SliderAlt;
            try
            {
                _slider.InsertSlider(slider);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteImage(string id)
        {
            var model = _slider.GetSliderById(id).Result;
            try
            {
                _slider.DeleteSlider(model);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

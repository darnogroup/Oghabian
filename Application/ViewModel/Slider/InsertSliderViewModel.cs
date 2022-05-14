using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Application.ViewModel.Slider
{
    public class InsertSliderViewModel
    {
       [Required(ErrorMessage = "تصویر اسلایدر را آپلود کنید")]
        public IFormFile SliderImageFile { set; get; }
        [Required(ErrorMessage = "متن جایگزین الزامی است")]
        public string SliderAlt { set; get; }
    }
}

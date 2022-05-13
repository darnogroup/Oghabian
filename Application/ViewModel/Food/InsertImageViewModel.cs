using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Application.ViewModel.Food
{
   public class InsertImageViewModel
    {
        public string FoodId { set; get; } 
        [Required(ErrorMessage = "تصویر را آپلود کنید")]
        public IFormFile Image { set; get; }
    }
}

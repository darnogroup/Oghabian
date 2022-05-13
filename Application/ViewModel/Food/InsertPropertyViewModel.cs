using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.Food
{
    public class InsertPropertyViewModel
    {
        [Required(ErrorMessage = "عنوان ویژگی الزامی است")]
        public string PropertyTitle { set; get; }
        [Required(ErrorMessage = "مقدار ویژگی الزامی است")]
        public string PropertyValue { set; get; }
        public string FoodId { set; get; }
    }
}

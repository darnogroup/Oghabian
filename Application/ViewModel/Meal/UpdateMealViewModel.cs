using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.Meal
{
    public class UpdateMealViewModel
    {
        [Required(ErrorMessage = "نام وعده غذایی را وارد کنید ")]
        public string MealName { set; get; }
        public string MealId { set; get; }
    }
}

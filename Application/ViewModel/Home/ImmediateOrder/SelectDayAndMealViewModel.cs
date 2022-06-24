using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Other;

namespace Application.ViewModel.Home.ImmediateOrder
{
    public class SelectDayAndMealViewModel
    {
        [Required(ErrorMessage ="انتخاب روز وعده غذایی را انتخاب کنید")]
        public Week Week { set; get; }
        [Required(ErrorMessage = "انتخاب  وعده غذایی را انتخاب کنید")]
        public string Meal { set; get; }
        public string Person { set; get; }
        public string FoodCalories { set; get; }
      
        public string FoodCarbohydrate { set; get; }
        public string SicknessId { set; get; }
        public string FoodFat { set; get; }

        public string FoodProtein { set; get; }
    }
}

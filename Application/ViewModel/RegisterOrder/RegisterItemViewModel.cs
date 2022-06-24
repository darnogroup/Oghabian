using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Other;

namespace Application.ViewModel.RegisterOrder
{
    public class RegisterItemViewModel
    {
        public bool Me { set; get; }
        public string Count { set; get; }
        public string FoodTitle { set; get; }
        public string Meal { set; get; }
        public Week Week { set; get; }
        public int FoodCalories { set; get; }
        public string FoodCarbohydrate { set; get; }
        public string FoodFat { set; get; }
        public string FoodCode { set; get; }
        public string FoodProtein { set; get; }
        public string FoodImage { set; get; }
    }
}

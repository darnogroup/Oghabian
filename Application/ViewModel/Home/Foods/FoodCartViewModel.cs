using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.Home.Foods
{
    public class FoodCartViewModel
    {
        public string FoodId { set; get; } 
        public string FoodTitle { set; get; }
        public int FoodPrice { set; get; }
        public int Rate { set; get; }
        public int FoodDiscountPrice { set; get; }
        public string FoodImage { set; get; }
        public string Category { set; get; }
    }
}

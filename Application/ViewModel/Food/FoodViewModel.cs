using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.Food
{
    public class FoodViewModel
    {
        public string FoodId { set; get; } 
        public string FoodTitle { set; get; }
        public string FoodPrice { set; get; }
 
        public string FoodImage { set; get; }
        public string FoodCount { set; get; }
    }
}

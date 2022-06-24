using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.Discount
{
    public class DiscountViewModel
    {
        public string DiscountId { set; get; } 
        public string DiscountCode { set; get; }
        public string DiscountTitle { set; get; }
        public string StartTime { set; get; }
        public string EndTime { set; get; }
    }
}

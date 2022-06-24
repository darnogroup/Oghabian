using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.Discount
{
    public class UpdateDiscountViewModel
    {
        public string Id { set; get; }
        [Required(ErrorMessage = "کد تخفیف الزامی است")]
        public string DiscountCode { set; get; }
        [Required(ErrorMessage = "عنوان  تخفیف الزامی است")]
        public string DiscountTitle { set; get; }
        [Required(ErrorMessage = "شروع تخفیف الزامی است")]
        public string StartTime { set; get; }
        [Required(ErrorMessage = "اتمام تخفیف الزامی است")]
        public string EndTime { set; get; }
        [Required(ErrorMessage = "مبلغ تخفیف الزامی است")]
        public string DiscountPrice { set; get; }
    }
}

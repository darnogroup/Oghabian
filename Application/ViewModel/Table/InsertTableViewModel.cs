using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.Table
{
    public class InsertTableViewModel
    {
        [Required(ErrorMessage = "نام جدول الزامی است")]
        public string Name { set; get; }
        [Required(ErrorMessage = " توضیح جدول الزامی است")]
        public string Description { set; get; }
        [Required(ErrorMessage = " انتخاب ستون الزامی است")]
        public string[] Rows { set; get; }
    }
}

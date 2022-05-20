using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.Table
{
    public class UpdateTableViewModel
    {
        [Required(ErrorMessage = "نام جدول الزامی است")]
        public string Name { set; get; }
        [Required(ErrorMessage = " توضیح جدول الزامی است")]
        public string Description { set; get; }
        [Required(ErrorMessage = " انتخاب سطر الزامی است")]
        public string[] Rows { set; get; }
        public string Id { set; get; }
    }
}
